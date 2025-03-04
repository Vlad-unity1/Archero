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

        private PlayerModel _player;

        private void Awake()
        {
            _player = _playerFactory.CreatePlayer(_spawnPoint, 100, _joystick);
            _enemyFactory.CreateEnemies();
        }

        private void FixedUpdate()
        {
            _player.Move();
        }
    }
}
