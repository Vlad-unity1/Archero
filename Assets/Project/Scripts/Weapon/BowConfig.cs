using Archer.Weapons;
using UnityEngine;

namespace Archero.BowConfiig
{
    [CreateAssetMenu(fileName = "New BowConfiig", menuName = "Weapon/BowConfiig", order = 52)]
    public class BowConfig : WeaponConfig
    {
        public GameObject BulletPrefab;
        public Transform BulletSpawnPosition;
    }
}