using Project.Scripts.Enemy;
using UnityEngine;

namespace Project.Scripts.Bullet
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        private BulletFactory _bulletFactory;
        private int _damage;

        public void Initialize(BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
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
            
            _bulletFactory.ReturnToPool(this, 0);
        }
    }
}