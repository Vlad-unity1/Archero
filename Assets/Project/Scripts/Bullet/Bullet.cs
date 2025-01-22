using Archero.BulletSpawner;
using UnityEngine;

namespace Archero.Bullets
{
    public class Bullet : MonoBehaviour
    {
        private BulletSpawn _bulletSpawn;

        public void Initialize(BulletSpawn bulletSpawn)
        {
            _bulletSpawn = bulletSpawn;
        }

        private void OnTriggerEnter(Collider other)
        {
            _bulletSpawn.ReturnToPool(gameObject, 0);
        }
    }
}