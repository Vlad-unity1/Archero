using UnityEngine;
using Weapons;

namespace Archero.EnemyModel
{
    public class Enemy : MonoBehaviour
    {
        public int MaxHealh { get; private set; }
        public int CurrentHealth { get; private set; }

        public Weapon CurrentWeapon { get; private set; }

        public Enemy(int maxHealth, Weapon currentWeapon)
        {
            MaxHealh = maxHealth;
            CurrentWeapon = currentWeapon;
        }

        public void Attack()
        {
            CurrentWeapon.StartAttacking();
        }

        public void SetEnemyWeapon(Weapon weapon)
        {
            CurrentWeapon = weapon;
        }
    }
}
