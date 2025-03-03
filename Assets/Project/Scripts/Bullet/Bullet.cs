using Project.Scripts.Enemies;
using System;
using UnityEngine;

namespace Project.Scripts.BulletModel
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        public event Action<Bullet> OnBulletHit;
        private int _damage;

        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyView enemyView))
            {
                var enemyModels = enemyView.GetEnemyModel();

                foreach (var enemyModel in enemyModels)
                {
                    if (enemyModel != null)
                    {
                        enemyModel.EnemyHealth.TakeDamage(_damage);
                    }
                }
            }

            OnBulletHit?.Invoke(this);
        }

        public void Shoot(Vector3 direction, float speed)
        {
            var rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(direction.normalized * speed, ForceMode.Impulse);
        }
    }
}