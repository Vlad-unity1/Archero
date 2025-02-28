using Project.Scripts.Bullet;
using Project.Scripts.Enemies;
using Project.Scripts.Enemy;
using Project.Scripts.Player;
using Project.Scripts.Weapons;
using UnityEngine;

namespace Project.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private BulletSpawner _bulletSpawn;
        [SerializeField] private Bullet.Bullet _bullet;
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Vector3 _spawnPoint;
        [SerializeField] private Joystick _joystick;

        private Player.Player _player;
        private PlayerHealth _health;
        private PlayerFactory _playerFactory;
        private EnemyHealth[] _enemyHealths;
        private Enemies.Enemy[] _enemies;

        private void Awake()
        {
            _bullet.Initialize(b => _bulletSpawn.ReturnToPool(b));
        }

        private void Start()
        {
            _playerFactory = new PlayerFactory(_weaponFactory, _playerPrefab);
            _health = new PlayerHealth(100);
            _player = _playerFactory.CreatePlayer(_spawnPoint, _health, _joystick);
            _enemies = _enemyFactory.CreateEnemies();
            _enemyHealths = new EnemyHealth[_enemies.Length];
            for (int i = 0; i < _enemies.Length; i++)
            {
                _enemyHealths[i] = _enemies[i].EnemyHealth;  
            } 

            _enemyView.Initialize(_enemies, _enemyHealths);
        }

        private void FixedUpdate()
        {
            _player.Move();
        }
    }
}
