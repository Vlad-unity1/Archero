using Project.Scripts.Enemy;
using Project.Scripts.Players;
using Project.Scripts.WeaponModel;
using System;
using System.Threading.Tasks;
using Project.Scripts.Weapons;

namespace Project.Scripts.PlayerModels
{
    public class PlayerModel
    {
        private const int ATTACK_DELAY = 250;

        public event Action OnAttackStart;
        public event Action OnAttackStop;

        public int Speed = 5; // test 
        private bool isAttacking;

        public Health PlayerHealth { get; private set; }
        private Weapon<BowConfig> CurrentWeapon { get; set; }

        private readonly PlayerMovement _playerMovement;
        private readonly Joystick _joystick;

        public PlayerModel(Health playerHealth, int speed, Weapon<BowConfig> currentWeapon, PlayerMovement playerMovement, Joystick joystick)
        {
            PlayerHealth = playerHealth;
            Speed = speed;
            CurrentWeapon = currentWeapon;
            _playerMovement = playerMovement;
            _joystick = joystick;
        }

        public void Move()
        {
            _playerMovement.Move();
        }

        public void StopAttacking()
        {
            isAttacking = false;
        }

        public async void StartAttack()
        {
            if (isAttacking) return;

            isAttacking = true;
            OnAttackStart?.Invoke();

            while (isAttacking)
            {
                CurrentWeapon.InstantAttack();
                OnAttackStart?.Invoke();
                
                await Task.Delay(ATTACK_DELAY);

                OnAttackStop?.Invoke();
            }
        }

        public void SetWeapon(Weapon<BowConfig> weapon)
        {
            CurrentWeapon = weapon;
        }

    }
}