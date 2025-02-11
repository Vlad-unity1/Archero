using UnityEngine;

namespace Project.Scripts.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private Enemy[] _enemies;
        public EnemyHealth[] EnemyHealths { get; private set; }

        public void Initialize(Enemy[] enemies, EnemyHealth[] enemyHealths)
        {
            _enemies = enemies;
            EnemyHealths = enemyHealths;
        }

        private void StartEnemyAttack(int index)
        {
            _enemies[index].Attack();
        }

        private void OnDeath(int index)
        {
            _enemies[index].Die();
        }
    }
}
