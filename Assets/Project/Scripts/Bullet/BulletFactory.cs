using Project.Scripts.Weapons;
using UnityEngine;

namespace Project.Scripts.BulletModel
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private int _initialPoolSize = 10;
        [SerializeField] private WeaponConfig _weaponConfig;

        private BulletPool _bulletPool;

        public void Awake()
        {
            _bulletPool = new BulletPool(_weaponConfig.BulletPrefab, _initialPoolSize);
        }

        public void SpawnAndShoot(Vector3 position, Quaternion rotation, Vector3 direction, float speed, int damage)
        {
            Bullet bullet = _bulletPool.GetBullet();
            bullet.transform.SetPositionAndRotation(position, rotation);
            bullet.gameObject.SetActive(true);

            bullet.SetDamage(damage);
            bullet.Shoot(direction, speed);

            bullet.OnBulletHit += ReturnToPool;
        }

        private void ReturnToPool(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            _bulletPool.ReturnBullet(bullet);

            bullet.OnBulletHit -= ReturnToPool;
        }
    }
}

