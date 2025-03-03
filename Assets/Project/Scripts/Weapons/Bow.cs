using Project.Scripts.BulletModel;
using Project.Scripts.WeaponModel;
using UnityEngine;

namespace Project.Scripts.Weapons
{
    public class Bow : Weapon<BowConfig>
    {
        private readonly Bullet _bulletPrefab;
        private readonly Transform _bulletPosition;
        private readonly BulletFactory _bulletSpawner;

        public Bow(BowConfig bowConfig, Bullet bulletPrefab, Transform bulletPosition, BulletFactory bulletSpawner)
            : base(bowConfig)
        {
            _bulletPrefab = bulletPrefab;
            _bulletPosition = bulletPosition;
            _bulletSpawner = bulletSpawner;
        }

        public override void InstantAttack()
        {
            var direction = _bulletPosition.forward;
            float speed = Config.BulletSpeed;
            var damage = Config.Damage;

            _bulletSpawner.SpawnAndShoot(_bulletPosition.position, Quaternion.identity, direction, speed, damage);
        }
    }
}