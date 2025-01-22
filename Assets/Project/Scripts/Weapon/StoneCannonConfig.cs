using Archer.Weapons;
using UnityEngine;

namespace Stone.Cannon.Config
{
    [CreateAssetMenu(fileName = "New StoneCannon", menuName = "Weapon/StoneCannon", order = 53)]
    public class StoneCannonConfig : WeaponConfig
    {
        public GameObject BulletPrefab;
        public Transform[] BulletSpawnPosition;
    }
}