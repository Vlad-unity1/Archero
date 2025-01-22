using Archer.PlayerStats;
using Archero.Bullets;
using Archero.BulletSpawner;
using Archero.EnemyModel;
using Archero.EnemyView;
using Archero.PlayerView;
using Archero.WeaponFactory;
using Arhcero.PlayerMovement;
using UnityEngine;
using Weapons;

namespace Archer.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        public Player Player { get; private set; }
        public Enemy Enemy { get; private set; }
        public Weapon CurrentWeapon { get; private set; }
        public Weapon CurrentWeaponEnemy { get; private set; }
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private BulletSpawn _bulletSpawn;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private EnemyView _enemyView;

        private void Awake()
        {
            _bulletSpawn.Initialize();
        }

        private void Start()
        {
            Player = new Player(100, 10, CurrentWeapon, _playerMovement);
            _playerMovement.Intialize(Player);
            CurrentWeapon = _weaponFactory.CreateWeapon();
            Player.SetWeapon(CurrentWeapon);
            _playerView.Initialize(Player);
            _bullet.Initialize(_bulletSpawn);

            Enemy = new Enemy(100, CurrentWeaponEnemy);
            CurrentWeaponEnemy = _weaponFactory.CreateEnemyWeapon();
            Enemy.SetEnemyWeapon(CurrentWeaponEnemy);
            _enemyView.Initialize(Enemy);
        }

        private void FixedUpdate()
        {
            Player.Move();
        }
    }
}
