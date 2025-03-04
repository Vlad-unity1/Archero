using Project.Scripts.BulletModel;
using Project.Scripts.WeaponModel;
using UnityEngine;

namespace Project.Scripts.Weapons
{
    public class Bow : Weapon<BowConfig>
    {
        private readonly Transform _bulletPosition;
        private readonly BulletFactory _bulletFactory;

        public Bow(BowConfig bowConfig, Transform bulletPosition, BulletFactory bulletFactory)
            : base(bowConfig)
        {
            _bulletPosition = bulletPosition;
            _bulletFactory = bulletFactory;
        }

        public override void InstantAttack()
        {
            var direction = _bulletPosition.forward;
            float speed = Config.BulletSpeed;
            var damage = Config.Damage;

            _bulletFactory.SpawnAndShoot(_bulletPosition.position, Quaternion.identity, direction, speed, damage);
        }
    }
}