using UnityEngine;

namespace Project.Scripts.Enemy
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfig", order = 59)]
    public class EnemyConfig : ScriptableObject
    {
        public GameObject PrefabEnemy;
        public EnemyHealth EnemyHealth;
        public Weapon.Weapon StartingWeapon;
        public int Health;

        private void OnValidate()
        {
            EnemyHealth ??= new EnemyHealth(Health);
        }
    }
}
