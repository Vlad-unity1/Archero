using UnityEngine;

namespace Project.Scripts.Weapons
{
    [CreateAssetMenu(fileName = "New WeaponConfig", menuName = "WeaponConfig", order = 51)]
    public abstract class WeaponConfig : ScriptableObject
    {
        public float BulletSpeed;
        public float FireRate;
        public int Damage;
    }
}