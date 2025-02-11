using Project.Scripts.Bullet;
using Project.Scripts.Enemy;
using Project.Scripts.Player;
using Project.Scripts.Weapon;
using UnityEngine;

namespace Project.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private BulletFactory _bulletSpawn;
        [SerializeField] private Bullet.Bullet _bullet;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private PlayerInputHandler _playerInputHandler;
        [SerializeField] private EnemyFactory _enemyFactory;

        private Player.Player _player;
        private PlayerHealth _health;
        private PlayerFactory _playerFactory;
        private EnemyHealth[] _enemyHealths;
        private Enemy.Enemy[] _enemies;

        private void Start()
        {
            _bulletSpawn.Initialize();

            _playerFactory = new PlayerFactory(_weaponFactory, _playerMovement, _playerInputHandler);
            _health = new PlayerHealth(100);
            _player = _playerFactory.CreatePlayer(_health);
            _playerView.Initialize(_player);

            _bullet.Initialize(_bulletSpawn);
            _enemies = _enemyFactory.CreateEnemies();

            _enemyHealths = new EnemyHealth[_enemies.Length];
            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemyHealths[i] = _enemies[i].GetHealth();  
            }

            _enemyView.Initialize(_enemies, _enemyHealths);

        }

        private void FixedUpdate()
        {
            _player.Move();
        }
    }
}
