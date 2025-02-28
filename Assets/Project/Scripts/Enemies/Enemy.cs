using System.Collections;
using Project.Scripts.Enemy;
using UnityEngine;

namespace Project.Scripts.Enemies
{
    public class Enemy
    {
        private Weapons.Weapon CurrentWeapon { get; set; }
        public EnemyHealth EnemyHealth { get; private set; }

        public Enemy(EnemyConfig config)
        {
            EnemyHealth = config.EnemyHealth;
            CurrentWeapon = config.StartingWeapon;
        }

        private void Attack()
        {
            CurrentWeapon.StartAttacking();
        }

        public void SetEnemyWeapon(Weapons.Weapon weapon)
        {
            CurrentWeapon = weapon;
        }
        
        public void SetEnemyHealth(EnemyHealth health)
        {
            EnemyHealth = health;
        }
        
        public IEnumerator AutoAttack()
        {
            while (true)
            {
                Attack();

                yield return new WaitForSeconds(CurrentWeapon.Config.FireRate);
            }
        }
    }
}