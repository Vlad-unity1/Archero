using Project.Scripts.BulletModel;
using Project.Scripts.WeaponModel;
using UnityEngine;

namespace Project.Scripts.Weapons
{
    public class StoneCannon : Weapon<StoneCannonConfig>
    {
        private readonly Bullet _bulletPrefab;
        private readonly Transform[] _bulletPosition;
        private readonly BulletFactory _bulletSpawner;

        public StoneCannon(StoneCannonConfig config, Bullet bulletPrefab, Transform[] bulletPosition, BulletFactory bulletSpawner)
           : base(config)
        {
            _bulletPrefab = bulletPrefab;
            _bulletPosition = bulletPosition;
            _bulletSpawner = bulletSpawner;
        }

        public override void InstantAttack()
        {
            foreach (var bulletPosition in _bulletPosition)
            {
                var position = bulletPosition.position;
                var direction = bulletPosition.forward;
                var speed = Config.BulletSpeed;
                var damage = Config.Damage;

                _bulletSpawner.SpawnAndShoot(position, Quaternion.identity, direction, speed, damage);
            }
        }
    }
}