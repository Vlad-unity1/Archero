using Project.Scripts.Enemies;
using Project.Scripts.PlayerModels;
using Project.Scripts.Players;
using UnityEngine;

namespace Project.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private PlayerFactory _playerFactory;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Joystick _joystick;

        private EnemyModel[] _enemies;
        private EnemyView _enemyView;
        private PlayerModel _player;
        private PlayerView _playerView;

        private void Awake()
        {
            _player = _playerFactory.CreatePlayer(_spawnPoint, 100, _joystick);
            _enemies = _enemyFactory.CreateEnemies();
        }

        private void Start()
        {
            _enemyView.Initialize(_enemies, _enemyView._weaponTransform);
            _playerView.Initialize(_player, _playerView._weaponTransform);
        }

        private void FixedUpdate()
        {
            _player.Move();
        }
    }
}
