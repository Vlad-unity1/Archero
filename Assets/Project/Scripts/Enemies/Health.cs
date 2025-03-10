﻿using System;
using UnityEngine;

namespace Project.Scripts.Enemy
{
    public class Health
    {
        public event Action OnEnemyDeath;
        public float MaxHealth { get; private set; }
        private float CurrentHealth { get; set; }

        public Health(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            Debug.Log($"Received {damage} damage. Current Health before: {CurrentHealth}");

            CurrentHealth -= damage;
            CurrentHealth = Mathf.Max(CurrentHealth, 0);

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