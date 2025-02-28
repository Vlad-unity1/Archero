using Project.Scripts.Enemy;
using UnityEngine;

namespace Project.Scripts.Enemies
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfig", order = 59)]
    public class EnemyConfig : ScriptableObject
    {
        public GameObject PrefabEnemy;
        public EnemyHealth EnemyHealth;
        public Weapons.Weapon StartingWeapon;

        private void OnValidate()
        {
            EnemyHealth ??= new EnemyHealth(100); // тут я вообще не понимаю как сделать установку здоровья правильно
        }
    }
}
