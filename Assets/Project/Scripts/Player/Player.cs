
namespace Project.Scripts.Player
{
    public class Player
    {
        public int Speed = 5; // test 

        private Weapons.Weapon CurrentWeapon { get; set; }
        public PlayerHealth CurrentHealth { get; private set; }
        private readonly PlayerMovement _playerMovement;
        private readonly Joystick _joystick; // я не могу разобраться почему он не используется, если он мне нужен

        public Player(PlayerHealth playerHealth, int speed, Weapons.Weapon currentWeapon, PlayerMovement playerMovement, Joystick joystick)
        {
            CurrentHealth = playerHealth;
            Speed = speed;
            CurrentWeapon = currentWeapon;
            _playerMovement = playerMovement;
            _joystick = joystick;
        }

        public void Attack()
        {
            CurrentWeapon.StartAttacking();
        }

        public void Move()
        {
            _playerMovement.Move();
        }

        public void SetWeapon(Weapons.Weapon weapon)
        {
            CurrentWeapon = weapon;
        }
    }
}