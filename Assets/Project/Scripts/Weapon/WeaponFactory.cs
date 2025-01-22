using UnityEngine;
using Archero.BulletSpawner;
using Archero.BowInstance;
using Archero.BowConfiig;
using Stone.Cannon;
using Stone.Cannon.Config;
using Weapons;

namespace Archero.WeaponFactory
{
    public class WeaponFactory : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private Transform _weaponMountPoint;
        [SerializeField] private BowConfig _bowConfig;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private BulletSpawn _bulletSpawner;

        [Header("EnemyModel")]
        [SerializeField] private GameObject _bulletEnemyPrefab;
        [SerializeField] private StoneCannonConfig _stoneCannonConfig;
        [SerializeField] private Transform[] _SpawnPoints;
        [SerializeField] private BulletSpawn _bulletSpawnerEnemy;

        public Weapon CreateWeapon()
        {
            Bow bow = new("Basic Bow", _bowConfig, _bulletPrefab, _weaponMountPoint, _bulletSpawner, _bowConfig.AttackSpeed);
            return bow;
        }

        public Weapon CreateEnemyWeapon()
        {
            StoneCannon stoneCannon = new("Stone Cannon", _stoneCannonConfig, _bulletEnemyPrefab, _SpawnPoints, _bulletSpawnerEnemy, _stoneCannonConfig.AttackSpeed);
            return stoneCannon;
        }
    }
}