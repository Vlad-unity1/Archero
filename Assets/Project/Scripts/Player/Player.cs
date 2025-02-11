namespace Project.Scripts.Player
{
    public class Player
    {
        public int Speed = 5; // test 

        public Weapon.Weapon CurrentWeapon { get; private set; }
        public PlayerHealth CurrentHealth { get; private set; }
        private readonly PlayerMovement _playerMovement;

        public Player(PlayerHealth playerHealth, int speed, Weapon.Weapon currentWeapon, PlayerMovement playerMovement)
        {
            CurrentHealth = playerHealth;
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

        public void SetWeapon(Weapon.Weapon weapon)
        {
            CurrentWeapon = weapon;
        }
    }
}