using System.Collections;
using Project.Scripts.Enemy;
using Project.Scripts.WeaponModel;
using Project.Scripts.Weapons;
using UnityEngine;

namespace Project.Scripts.Enemies
{
    public class EnemyModel
    {
        private Weapon<StoneCannonConfig> CurrentWeapon { get; set; }
        public Health EnemyHealth { get; private set; }

        public EnemyModel(EnemyConfig config)
        {
            CurrentWeapon = config.StartingWeaponConfig;
        }

        private void Attack()
        {
            CurrentWeapon.InstantAttack();
        }

        public void SetEnemyWeapon(Weapon<StoneCannonConfig> weapon)
        {
            CurrentWeapon = weapon;
        }

        public void SetEnemyHealth(Health health)
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