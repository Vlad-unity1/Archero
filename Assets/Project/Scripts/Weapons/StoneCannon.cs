using Project.Scripts.BulletModel;
using Project.Scripts.WeaponModel;
using UnityEngine;

namespace Project.Scripts.Weapons
{
    public class StoneCannon : Weapon<StoneCannonConfig>
    {
        private readonly Transform[] _bulletPosition;
        private readonly BulletFactory _bulletSpawner;

        public StoneCannon(StoneCannonConfig config, Transform[] bulletPosition, BulletFactory bulletFactory)
           : base(config)
        {
            _bulletPosition = bulletPosition;
            _bulletSpawner = bulletFactory;
        }

        public override void InstantAttack()
        {
            foreach (var bulletPosition in _bulletPosition)
            {
                if (bulletPosition == null) 
                    continue;

                var position = bulletPosition.position;
                var direction = bulletPosition.forward;
                var speed = Config.BulletSpeed;
                var damage = Config.Damage;

                _bulletSpawner.SpawnAndShoot(position, Quaternion.identity, direction, speed, damage);
            }
        }
    }
}