namespace Project.Scripts.Enemy
{
    public class Enemy
    {
        private Weapon.Weapon CurrentWeapon { get; set; }
        public EnemyHealth EnemyHealth { get;  set; }

        public Enemy(EnemyConfig config)
        {
            EnemyHealth = config.EnemyHealth;
            CurrentWeapon = config.StartingWeapon;
        }

        public void Attack()
        {
            CurrentWeapon.StartAttacking();
        }

        public void SetEnemyWeapon(Weapon.Weapon weapon)
        {
            CurrentWeapon = weapon;
        }
        
        public void SetEnemyHealth(EnemyHealth health)
        {
            EnemyHealth = health;
        }

        public EnemyHealth GetHealth()
        {
            return EnemyHealth;
        }

        public void Move()
        {
            // Move
        }

        public void Die()
        {
           // Die
        }
    }
}