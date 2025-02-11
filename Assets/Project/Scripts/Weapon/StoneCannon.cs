using Project.Scripts.Bullet;
using Stone.Cannon.Config;
using UnityEngine;

namespace Project.Scripts.Weapon
{
    public class StoneCannon : Weapon
    {
        private readonly Bullet.Bullet _bulletPrefab;
        private readonly Transform[] _bulletPosition;
        private readonly IBulletSpawner _bulletSpawner;

        public StoneCannon(StoneCannonConfig config, Bullet.Bullet bulletPrefab, Transform[] bulletPosition, IBulletSpawner bulletSpawner)
           : base(config)
        {
            _bulletPrefab = bulletPrefab;
            _bulletPosition = bulletPosition;
            _bulletSpawner = bulletSpawner;
        }

        public override void StartAttacking()
        {
            foreach (var bulletPosition in _bulletPosition)
            {
                var stoneCannonConfig = (StoneCannonConfig)Config;
                
                var bullet = _bulletSpawner.SpawnBullet(_bulletPrefab, bulletPosition.position, Quaternion.identity);
                var direction = bulletPosition.forward;
                var speed = stoneCannonConfig.BulletSpeed;

                _bulletSpawner.ShootProjectile(bullet, direction, speed);
            }
        }
    }
}