using Project.Scripts.BulletModel;
using Project.Scripts.WeaponModel;
using UnityEngine;

namespace Project.Scripts.Weapons
{
    public class WeaponFactory : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private BowConfig _bowConfig;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private BulletFactory _bulletFactory;

        [Header("EnemyModel")]
        [SerializeField] private Bullet _bulletEnemyPrefab;
        [SerializeField] private StoneCannonConfig _stoneCannonConfig;
        [SerializeField] private BulletFactory _bulletFactoryEnemy;

        public Weapon<BowConfig> CreateWeapon(Transform spawnPoint)
        {
            return new Bow(_bowConfig, _bulletPrefab, spawnPoint, _bulletFactory);
        }

        public Weapon<StoneCannonConfig> CreateEnemyWeapon(Transform[] spawnPoints)
        {
            return new StoneCannon(_stoneCannonConfig, _bulletEnemyPrefab, spawnPoints, _bulletFactoryEnemy);
        }
    }
}