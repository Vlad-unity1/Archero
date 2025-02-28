using Project.Scripts.Bullet;
using UnityEngine;

namespace Project.Scripts.Weapons
{
    public class StoneCannon : Weapon
    {
        private readonly Bullet.Bullet _bulletPrefab; // такой же вопрос как с луком
        private readonly Transform[] _bulletPosition;
        private readonly BulletSpawner _bulletSpawner;

        public StoneCannon(StoneCannonConfig config, Bullet.Bullet bulletPrefab, Transform[] bulletPosition, BulletSpawner bulletSpawner)
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
                var position = bulletPosition.position;
                var direction = bulletPosition.forward;
                var speed = stoneCannonConfig.BulletSpeed;

                _bulletSpawner.SpawnAndShoot(position, Quaternion.identity, direction, speed );
            }
        }
    }
}