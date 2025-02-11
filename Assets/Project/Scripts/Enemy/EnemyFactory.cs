using Project.Scripts.Weapon;
using UnityEngine;

namespace Project.Scripts.Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private EnemyConfig[] _enemyConfigs;
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private Transform[] _spawnPoints;

        public Enemy[] CreateEnemies()
        {
            Enemy[] enemies = new Enemy[_spawnPoints.Length];

            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                var spawnPoint = _spawnPoints[i];
                EnemyConfig config = _enemyConfigs[i];

                GameObject enemyObject = Instantiate(config.PrefabEnemy, spawnPoint.position, Quaternion.identity);
                enemyObject.transform.position = spawnPoint.position;
                Transform[] stoneCannonSpawnPoints = enemyObject.GetComponentsInChildren<Transform>();
                
                Weapon.Weapon enemyWeapon = _weaponFactory.CreateEnemyWeapon(stoneCannonSpawnPoints);
                config.StartingWeapon = enemyWeapon;

                EnemyHealth enemyHealth = new(config.EnemyHealth.MaxHealth);

                Enemy enemy;
                
                if (config is EnemyStoneConfig stoneConfig)
                {
                    enemy = new StoneEnemy(stoneConfig, this);
                }
                else
                {
                    enemy = new Enemy(config);
                }
                
                enemy.SetEnemyWeapon(enemyWeapon);
                enemy.SetEnemyHealth(enemyHealth);

                enemies[i] = enemy;
            }

            return enemies;
        }
    }
}
