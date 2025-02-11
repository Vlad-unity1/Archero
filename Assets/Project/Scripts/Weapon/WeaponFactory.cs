using Project.Scripts.Bullet;
using Project.Scripts.Enemy;
using Stone.Cannon;
using Stone.Cannon.Config;
using UnityEngine;

namespace Project.Scripts.Weapon
{
    public class WeaponFactory : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private Transform _weaponMountPoint;
        [SerializeField] private BowConfig _bowConfig;
        [SerializeField] private Bullet.Bullet _bulletPrefab;
        [SerializeField] private BulletFactory _bulletSpawner;

        [Header("EnemyModel")]
        [SerializeField] private Bullet.Bullet _bulletEnemyPrefab;
        [SerializeField] private StoneCannonConfig _stoneCannonConfig;
        [SerializeField] private BulletFactory _bulletSpawnerEnemy;

        public Weapon CreateWeapon()
        {
            Bow bow = new(_bowConfig, _bulletPrefab, _weaponMountPoint, _bulletSpawner);
            return bow;
        }

        public Weapon CreateEnemyWeapon(Transform[] spawnPoints)
        {
            StoneCannon stoneCannon = new(_stoneCannonConfig, _bulletEnemyPrefab, spawnPoints, _bulletSpawnerEnemy);
            return stoneCannon;
        }
    }
}