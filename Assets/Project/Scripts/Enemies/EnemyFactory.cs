using Project.Scripts.Enemy;
using Project.Scripts.WeaponModel;
using Project.Scripts.Weapons;
using UnityEngine;

namespace Project.Scripts.Enemies
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private EnemySpawnData[] _enemySpawnData;

        public EnemyModel[] CreateEnemies()
        {
            EnemyModel[] enemies = new EnemyModel[_enemySpawnData.Length];

            for (int i = 0; i < _enemySpawnData.Length; i++)
            {
                var data = _enemySpawnData[i];

                EnemyView enemyObject = Instantiate(data.Config.PrefabEnemy, data.SpawnPoint.position, Quaternion.identity);
                enemyObject.transform.position = data.SpawnPoint.position;
                Transform[] stoneCannonSpawnPoints = enemyObject.WeaponTransform;
                Weapon<StoneCannonConfig> enemyWeapon = _weaponFactory.CreateEnemyWeapon(stoneCannonSpawnPoints);
                data.Config.StartingWeaponConfig = enemyWeapon;
                Health enemyHealth = new(data.Config.MaxHealth);
                EnemyModel enemy;

                if (data.Config is EnemyStoneConfig stoneConfig)
                {
                    enemy = new StoneEnemy(stoneConfig, _weaponFactory);
                }
                else
                {
                    enemy = new EnemyModel(data.Config);
                }

                enemy.SetEnemyWeapon(enemyWeapon);
                enemy.SetEnemyHealth(enemyHealth);
                enemies[i] = enemy;

                enemyObject.Initialize(enemy, enemyObject.WeaponTransform);
            }

            return enemies;
        }
    }
}
