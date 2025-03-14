using NextLevelLoader;
using Project.Scripts.Enemies;
using Project.Scripts.Players;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private PlayerFactory _playerFactory;
    [SerializeField] private SpawnPointPlayerScene _spawnPointPlayer;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private NextLevel _door;

    public override void InstallBindings()
    {
        Container.BindInstance(_enemyFactory).AsSingle();
        Container.BindInstance(_playerFactory).AsSingle();
        Container.BindInstance(_spawnPointPlayer).AsSingle();
        Container.BindInstance(_joystick).AsSingle();
        Container.BindInstance(_door).AsSingle();

        Container.BindInterfacesAndSelfTo<GameFlow>().AsSingle();
    }
}