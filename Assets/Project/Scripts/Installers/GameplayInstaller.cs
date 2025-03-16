using NextLevelLoader;
using Project.Scripts.BulletModel;
using Project.Scripts.Enemies;
using Project.Scripts.Players;
using Project.Scripts.Weapons;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private PlayerFactory _playerFactory;
    [SerializeField] private SpawnPointPlayerScene _spawnPointPlayer;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private NextLevel _door;
    [SerializeField] private BowConfig _bowConfig;
    [SerializeField] private StoneCannonConfig _stoneCannonConfig;

    public override void InstallBindings()
    {
        Container.BindInstance(_enemyFactory).AsSingle();
        Container.BindInstance(_playerFactory).AsSingle();
        Container.BindInstance(_spawnPointPlayer).AsSingle();
        Container.BindInstance(_joystick).AsSingle();
        Container.BindInstance(_door).AsSingle();

        Container.Bind<WeaponFactory>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BowConfig>().FromInstance(_bowConfig).AsSingle();
        Container.Bind<StoneCannonConfig>().FromInstance(_stoneCannonConfig).AsSingle();
        Container.Bind<BulletFactoryEnemies>().AsSingle().WithArguments(_stoneCannonConfig, 10);
        Container.Bind<BulletFactoryPlayer>().AsSingle().WithArguments(_bowConfig, 10);
        Container.BindInterfacesAndSelfTo<GameFlow>().AsSingle();
    }
}
