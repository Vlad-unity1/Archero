using Archer.IPlayerInterface;
using Arhcero.PlayerMovement;
using Weapons;

namespace Archer.PlayerStats
{
    public class Player : IAttackAndMove
    {
        public int MaxHealh { get; private set; }
        public int CurrentHealth { get; private set; }
        public int Speed = 5; // test 

        public Weapon CurrentWeapon { get; private set; }
        private readonly PlayerMovement _playerMovement;

        public Player(int maxHealth, int speed, Weapon currentWeapon, PlayerMovement playerMovement)
        {
            MaxHealh = maxHealth;
            Speed = speed;
            CurrentWeapon = currentWeapon;
            _playerMovement = playerMovement;
        }

        public void Attack()
        {
            CurrentWeapon.StartAttacking();
        }

        public void Move()
        {
            _playerMovement.Move();
        }

        public void SetWeapon(Weapon weapon)
        {
            CurrentWeapon = weapon;
        }
    }
}