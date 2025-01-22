using UnityEngine;

namespace Archer.Weapons
{
    [CreateAssetMenu(fileName = "New WeaponConfig", menuName = "WeaponConfig", order = 51)]
    public abstract class WeaponConfig : ScriptableObject
    {
        public string ItemName;
        public int Damage;
        public float AttackSpeed;
    }
}