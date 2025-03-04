using Project.Scripts.BulletModel;
using Project.Scripts.WeaponModel;
using UnityEngine;

namespace Project.Scripts.Weapons
{
    public class WeaponFactory : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private BowConfig _bowConfig;
        [SerializeField] private BulletFactory _bulletFactory;

        [Header("EnemyModel")]
        [SerializeField] private StoneCannonConfig _stoneCannonConfig;
        [SerializeField] private BulletFactory _bulletFactoryEnemy;

        public Weapon<BowConfig> CreateWeapon(Transform spawnPoint)
        {
            return new Bow(_bowConfig, spawnPoint, _bulletFactory);
        }

        public Weapon<StoneCannonConfig> CreateEnemyWeapon(Transform[] spawnPoints)
        {
            return new StoneCannon(_stoneCannonConfig, spawnPoints, _bulletFactoryEnemy);
        }
    }
}