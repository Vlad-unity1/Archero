using System.Collections;
using UnityEngine;

namespace Project.Scripts.Enemy
{
    public class StoneEnemy : Enemy
    {
        private readonly float _attackDelay;
        private readonly MonoBehaviour _coroutineRunner;

        public StoneEnemy(EnemyStoneConfig config, MonoBehaviour coroutineRunner)
            : base(config)
        {
            _attackDelay = config.AttackDelay;
            Debug.Log($"Attack Delay установлен на: {_attackDelay}");
            
            _coroutineRunner = coroutineRunner;

            StartAutoAttack();
        }

        private void StartAutoAttack()
        {
            _coroutineRunner.StartCoroutine(AutoAttack());
        }

        private IEnumerator AutoAttack()
        {
            while (true)
            {
                Attack();

                yield return new WaitForSeconds(_attackDelay);
            }
        }
    }
}
