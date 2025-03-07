using Project.Scripts.Enemies;
using Project.Scripts.Players;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private PlayerFactory _playerFactory;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Joystick _joystick;

    public override void InstallBindings()
    {
        Container.BindInstance(_enemyFactory).AsSingle();
        Container.BindInstance(_playerFactory).AsSingle();
        Container.BindInstance(_spawnPoint).AsSingle();
        Container.BindInstance(_joystick).AsSingle();

        Container.BindInterfacesAndSelfTo<GameFlow>().AsSingle();
    }
}