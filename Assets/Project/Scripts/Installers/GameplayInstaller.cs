using NextLevelLoader;
using Project.Scripts.BulletFactoryEnemy;
using Project.Scripts.BulletModel;
using Project.Scripts.Enemies;
using Project.Scripts.Players;
using Project.Scripts.Weapons;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Scripts.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private SpawnPointPlayerScene _spawnPointPlayer;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private NextLevel _door;
        [SerializeField] private BowConfig _bowConfig;
        [SerializeField] private StoneCannonConfig _stoneCannonConfig;
        [SerializeField] private EnemySpawnData[] _enemySpawnData;
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private Slider _slider;

        public override void InstallBindings()
        {
            Container.BindInstance(_spawnPointPlayer).AsSingle();
            Container.BindInstance(_joystick).AsSingle();
            Container.BindInstance(_door).AsSingle();
            Container.BindInstance(_enemySpawnData).AsSingle();
            Container.BindInstance(_sceneData).AsSingle();
            Container.BindInstance(_weaponFactory).AsSingle();
            Container.BindInstance(_slider).AsSingle();

            Container.Bind<PlayerFactory>().AsSingle().WithArguments(_weaponFactory, _sceneData);
            Container.Bind<EnemyFactory>().AsSingle().WithArguments(_weaponFactory, _sceneData);
            Container.Bind<BowConfig>().FromInstance(_bowConfig).AsSingle();
            Container.Bind<StoneCannonConfig>().FromInstance(_stoneCannonConfig).AsSingle();
            Container.Bind<BulletFactoryEnemies>().AsSingle().WithArguments(_stoneCannonConfig, 10);
            Container.Bind<BulletFactoryPlayer>().AsSingle().WithArguments(_bowConfig, 10);
            Container.BindInterfacesAndSelfTo<GameFlow>().AsSingle();
        }
    }
}
