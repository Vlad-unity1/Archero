using Project.Scripts.Bullet;
using UnityEngine;

namespace Project.Scripts.Weapons
{
    public class Bow : Weapon
    {
        private readonly BowConfig _bowConfig;
        private readonly Bullet.Bullet _bulletPrefab;
        private readonly Transform _bulletPosition;
        private readonly BulletSpawner _bulletSpawner;

        public Bow(BowConfig bowConfig, Bullet.Bullet bulletPrefab, Transform bulletPosition, BulletSpawner bulletSpawner)
            : base(bowConfig)
        {
            _bowConfig = bowConfig; 
            _bulletPrefab = bulletPrefab;
            _bulletPosition = bulletPosition;
            _bulletSpawner = bulletSpawner;
        }

        public override void StartAttacking()
        {
            var direction = _bulletPosition.forward;
            float speed = _bowConfig.BulletSpeed; 
            var damage = _bulletPrefab.SetDamage(_bowConfig.Damage);

            _bulletSpawner.SpawnAndShoot(_bulletPosition.position, Quaternion.identity, direction, speed, damage);
        }
    }
}