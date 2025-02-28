using Project.Scripts.Enemies;
using Project.Scripts.Weapons;
using UnityEngine;

namespace Project.Scripts.Enemy
{
    public class StoneEnemy : Enemies.Enemy
    {
        private readonly MonoBehaviour _coroutineRunner;

        public StoneEnemy(EnemyStoneConfig config, WeaponFactory coroutineRunner)
            : base(config)
        {
            _coroutineRunner = coroutineRunner;

            StartAutoAttack();
        }

        private void StartAutoAttack()
        {
            _coroutineRunner.StartCoroutine(AutoAttack());
        }
    }
}
