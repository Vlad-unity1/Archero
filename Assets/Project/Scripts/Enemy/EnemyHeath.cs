using System;
using UnityEngine;

namespace Project.Scripts.Enemy
{
    public class EnemyHealth
    {
        public event Action OnEnemyDeath;
        public float MaxHealth { get; private set; }
        private float CurrentHealth { get; set; }

        public EnemyHealth(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            CurrentHealth = Mathf.Max(CurrentHealth, 0);

            Debug.Log($"Враг получил {damage} урона. Текущее HP: {CurrentHealth}");

            if (CurrentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            OnEnemyDeath?.Invoke();
        }
    }
}