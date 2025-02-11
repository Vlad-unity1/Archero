using Archer.Weapons;

namespace Project.Scripts.Weapon
{
    public abstract class Weapon
    {
        public WeaponConfig Config { get; private set; }

        public Weapon(WeaponConfig config)
        {
            Config = config;
        }

        public abstract void StartAttacking();
    }
}