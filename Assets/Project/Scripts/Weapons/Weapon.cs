using Project.Scripts.Weapons;

namespace Project.Scripts.WeaponModel
{
    public abstract class Weapon<T> where T : WeaponConfig
    {
        public T Config { get; }

        protected Weapon(T config)
        {
            Config = config;
        }

        public abstract void InstantAttack();
    }
}