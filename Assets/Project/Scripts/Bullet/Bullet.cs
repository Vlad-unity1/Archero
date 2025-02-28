using System;
using Project.Scripts.Enemies;
using Project.Scripts.Enemy;
using UnityEngine;

namespace Project.Scripts.Bullet
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private Action<Bullet> _onReturnToPool;
        private int _damage;

        public void Initialize(Action<Bullet> onReturnToPool)
        {
            _onReturnToPool = onReturnToPool;
        }
        
        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyView enemy))
            {
                if (enemy.EnemyHealths.Length > 0)
                {
                    enemy.EnemyHealths[0].TakeDamage(_damage);
                }
            }
            
            _onReturnToPool?.Invoke(this);
        }

        public void Shoot(Vector3 direction, float speed)
        {
            var rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(direction.normalized * speed, ForceMode.Impulse);
        }
    }
}