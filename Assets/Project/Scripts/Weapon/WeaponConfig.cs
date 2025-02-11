using UnityEngine;
using UnityEngine.Serialization;

namespace Archer.Weapons
{
    [CreateAssetMenu(fileName = "New WeaponConfig", menuName = "WeaponConfig", order = 51)]
    public abstract class WeaponConfig : ScriptableObject
    {
        public float BulletSpeed;
        public int Damage; 
    }
}