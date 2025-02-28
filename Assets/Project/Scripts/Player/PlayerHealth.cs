using UnityEngine;

namespace Project.Scripts.Player
{
    public class PlayerHealth
    {
        public float MaxHealth { get; private set; }
        private float CurrentHealth { get; set; }

        public PlayerHealth(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }
        
        public void TakeDamage(float damage) // пока что не придумал как реализовать атаку по герою, нужно больше врагов для этого
        {
            CurrentHealth -= damage;
            CurrentHealth = Mathf.Max(CurrentHealth, 0);

            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            // логика смерти позже сделаю
        }
    }
}