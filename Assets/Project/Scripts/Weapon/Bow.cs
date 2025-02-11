using Project.Scripts.Bullet;
using UnityEngine;

namespace Project.Scripts.Weapon
{
    public class Bow : Weapon
    {
        private readonly Bullet.Bullet _bulletPrefab;
        private readonly Transform _bulletPosition;
        private readonly IBulletSpawner _bulletSpawner;

        public Bow(BowConfig config, Bullet.Bullet bulletPrefab, Transform bulletPosition, IBulletSpawner bulletSpawner)
           : base(config)
        {
            _bulletPrefab = bulletPrefab;
            _bulletPosition = bulletPosition;
            _bulletSpawner = bulletSpawner;
        }

        public override void StartAttacking()
        {
            var bowConfig = (BowConfig)Config;
            
            var bullet = _bulletSpawner.SpawnBullet(_bulletPrefab, _bulletPosition.position, Quaternion.identity);
            bullet.SetDamage(bowConfig.Damage);
            var direction = _bulletPosition.forward;
            float speed = bowConfig.BulletSpeed;

            _bulletSpawner.ShootProjectile(bullet, direction, speed);
        }
    }
}