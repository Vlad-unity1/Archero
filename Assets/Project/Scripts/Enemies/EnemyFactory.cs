using Project.Scripts.Enemy;
using Project.Scripts.WeaponModel;
using Project.Scripts.Weapons;
using System.Collections.Generic;
using Project.Scripts.HealthInfo;
using UnityEngine;

namespace Project.Scripts.Enemies
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private EnemySpawnData[] _enemySpawnData;

        private readonly List<EnemyModel> _enemies = new();

        public EnemyModel[] CreateEnemies()
        {
            EnemyModel[] enemies = new EnemyModel[_enemySpawnData.Length];
            _enemies.Clear();

            for (int i = 0; i < _enemySpawnData.Length; i++)
            {
                var data = _enemySpawnData[i];

                EnemyView enemyObject = Instantiate(data.Config.PrefabEnemy, data.SpawnPoint.position, Quaternion.identity);
                enemyObject.transform.position = data.SpawnPoint.position;
                Transform[] stoneCannonSpawnPoints = enemyObject.WeaponTransform;
                Weapon<StoneCannonConfig> enemyWeapon = _weaponFactory.CreateEnemyWeapon(stoneCannonSpawnPoints);
                data.Config.StartingWeaponConfig = enemyWeapon;
                Health enemyHealth = new(data.Config.MaxHealth, enemyObject.gameObject);
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
                _enemies.Add(enemy);

                enemyObject.Initialize(enemy, enemyObject.WeaponTransform, enemyHealth);
            }

            return enemies;
        }

        public List<EnemyModel> GetAllEnemies()
        {
            return _enemies;
        }
    }
}
