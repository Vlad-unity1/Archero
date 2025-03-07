using Project.Scripts.Enemies;
using Project.Scripts.PlayerModels;
using Project.Scripts.Players;
using UnityEngine;
using Zenject;

public class GameFlow : IInitializable, ITickable
{
    private readonly EnemyFactory _enemyFactory;
    private readonly PlayerFactory _playerFactory;
    private readonly Transform _spawnPoint;
    private readonly Joystick _joystick;
    private PlayerModel _player;

    public GameFlow(EnemyFactory enemyFactory, PlayerFactory playerFactory, Transform spawnPoint, Joystick joystick)
    {
        _enemyFactory = enemyFactory;
        _playerFactory = playerFactory;
        _spawnPoint = spawnPoint;
        _joystick = joystick;
    }

    public void Initialize()
    {
        _player = _playerFactory.CreatePlayer(_spawnPoint, 100, _joystick);
        _enemyFactory.CreateEnemies();
    }

    public void Tick()
    {
        _player.Move();
    }
}
