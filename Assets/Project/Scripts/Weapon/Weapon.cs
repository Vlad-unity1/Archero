using Archer.Weapons;

namespace Weapons
{
    public abstract class Weapon
    {
        public string Name { get; private set; }
        public WeaponConfig Config { get; private set; }
        public float AttackSpeed { get; private set; }

        public Weapon(string name, WeaponConfig config, float attackSpeed)
        {
            Name = name;
            Config = config;
            AttackSpeed = attackSpeed;
        }

        public abstract void StartAttacking();
    }
}