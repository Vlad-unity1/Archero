using Archero.BowConfiig;
using UnityEngine;
using Weapons;

namespace Archero.BowInstance
{
    public class Bow : Weapon
    {
        public GameObject _bulletPrefab;
        private readonly Transform _bulletPosition;
        private readonly IBulletSpawner _bulletSpawner;

        public Bow(string name, BowConfig config, GameObject bulletPrefab, Transform bulletPosition, IBulletSpawner bulletSpawner, float attackSpeed)
           : base(name, config, attackSpeed)
        {
            _bulletPrefab = bulletPrefab;
            _bulletPosition = bulletPosition;
            _bulletSpawner = bulletSpawner;
        }

        public override void StartAttacking()
        {
            GameObject bullet = _bulletSpawner.SpawnBullet(_bulletPrefab, _bulletPosition.position, Quaternion.identity);
            Vector3 direction = _bulletPosition.forward;
            float speed = ((BowConfig)Config).AttackSpeed;

            _bulletSpawner.SetupBullet(bullet, direction, speed);
        }
    }
}