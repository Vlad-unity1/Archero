using System.Collections;
using UnityEngine;
using Archero.EnemyModel;

namespace Archero.EnemyView
{
    public class EnemyView : MonoBehaviour
    {
        private const float ATTACK_DELAY = 3f;
        private const float ROTATION_SPEED = 45f;

        [SerializeField] private GameObject _enemyPrefab;
        private Enemy _enemy;
        private Coroutine _autoAttackCoroutine;

        public void Initialize(Enemy enemy)
        {
            _enemy = enemy;
            StartAttacking();
        }

        private void StartAttacking()
        {
            _autoAttackCoroutine ??= StartCoroutine(AutoAttack());
        }

        private IEnumerator AutoAttack()
        {
            while (true)
            {
                _enemy.Attack();

                float elapsedTime = 0f;

                while (elapsedTime < ATTACK_DELAY)
                {
                    float rotationStep = ROTATION_SPEED * Time.deltaTime;
                    _enemyPrefab.transform.Rotate(0, rotationStep, 0);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
            }
        }
    }
}