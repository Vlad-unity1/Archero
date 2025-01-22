using Stone.Cannon.Config;
using UnityEngine;
using Weapons;

namespace Stone.Cannon
{
    public class StoneCannon : Weapon
    {
        public GameObject _bulletPrefab;
        private readonly Transform[] _bulletPosition;
        private readonly IBulletSpawner _bulletSpawner;

        public StoneCannon(string name, StoneCannonConfig config, GameObject bulletPrefab, Transform[] bulletPosition, IBulletSpawner bulletSpawner, float attackSpeed)
           : base(name, config, attackSpeed)
        {
            _bulletPrefab = bulletPrefab;
            _bulletPosition = bulletPosition;
            _bulletSpawner = bulletSpawner;
        }

        public override void StartAttacking()
        {
            foreach (var bulletPosition in _bulletPosition)
            {
                GameObject bullet = _bulletSpawner.SpawnBullet(_bulletPrefab, bulletPosition.position, Quaternion.identity);
                Vector3 direction = bulletPosition.forward;
                float speed = ((StoneCannonConfig)Config).AttackSpeed;

                _bulletSpawner.SetupBullet(bullet, direction, speed);
            }
        }
    }
}