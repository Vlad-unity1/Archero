using NextLevelLoader;
using Project.Scripts.Enemies;
using Project.Scripts.PlayerModels;
using Project.Scripts.Players;
using System.Collections.Generic;
using Zenject;

public class GameFlow : IInitializable, ITickable
{
    private List<EnemyModel> _enemies;
    private readonly EnemyFactory _enemyFactory;
    private readonly PlayerFactory _playerFactory;
    private readonly SpawnPointPlayerScene _spawnPointPlayer;
    private readonly Joystick _joystick;
    private readonly NextLevel _nextLevelController;
    private PlayerModel _player;

    public GameFlow(EnemyFactory enemyFactory, PlayerFactory playerFactory, SpawnPointPlayerScene spawnPointPlayer, Joystick joystick, NextLevel nextLevelController)
    {
        _enemyFactory = enemyFactory;
        _playerFactory = playerFactory;
        _spawnPointPlayer = spawnPointPlayer;
        _joystick = joystick;
        _nextLevelController = nextLevelController;
    }

    public void Initialize()
    {
        _nextLevelController.DisablePanels();
        _player = _playerFactory.CreatePlayer(_spawnPointPlayer, 100, _joystick);
        _enemyFactory.CreateEnemies();
        _enemies = _enemyFactory.GetAllEnemies();

        _player.PlayerHealth.OnEntityDeath += RemovePlayer;

        foreach (var enemy in _enemies)
        {
            enemy.EnemyHealth.OnEntityDeath += () => RemoveEnemy(enemy);
        }
    }

    private void RemoveEnemy(EnemyModel enemy)
    {
        enemy.EnemyHealth.OnEntityDeath -= () => RemoveEnemy(enemy);
        _enemies.Remove(enemy);

        if (_enemies.Count == 0)
        {
            OnAllEnemiesDefeated();
        }
    }

    private void OnAllEnemiesDefeated()
    {
        _nextLevelController.EnableCollider();
    }

    private void RemovePlayer()
    {
        _player.PlayerHealth.OnEntityDeath -= RemovePlayer;
        OnAllPlayersDefeated();
    }

    private void OnAllPlayersDefeated()
    {
        _nextLevelController.EnablePanel();
    }

    public void Tick()
    {
        _player?.Move();
    }
}
