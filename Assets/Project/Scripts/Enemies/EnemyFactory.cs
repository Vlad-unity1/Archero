using Project.Scripts.Enemy;
using Project.Scripts.Weapons;
using UnityEngine;

namespace Project.Scripts.Enemies
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private EnemySpawnData[] _enemySpawnData;
        
        public Enemy[] CreateEnemies()
        {
            Enemy[] enemies = new Enemy[_enemySpawnData.Length];

            for (int i = 0; i < _enemySpawnData.Length; i++)
            {
                var data = _enemySpawnData[i];
                
                GameObject enemyObject = Instantiate(data.Config.PrefabEnemy, data.SpawnPoint.position, Quaternion.identity);
                enemyObject.transform.position = data.SpawnPoint.position;
                Transform[] stoneCannonSpawnPoints = enemyObject.GetComponentsInChildren<Transform>();
                Weapon enemyWeapon = _weaponFactory.CreateEnemyWeapon(stoneCannonSpawnPoints);
                data.Config.StartingWeapon = enemyWeapon;
                EnemyHealth enemyHealth = new(data.Config.EnemyHealth.MaxHealth);
                Enemy enemy;
        
                if (data.Config is EnemyStoneConfig stoneConfig)
                {
                    enemy = new StoneEnemy(stoneConfig, _weaponFactory);
                }
                else
                {
                    enemy = new Enemy(data.Config);
                }
        
                enemy.SetEnemyWeapon(enemyWeapon);
                enemy.SetEnemyHealth(enemyHealth);
                enemies[i] = enemy;
            }

            return enemies;
        }
    }
}
