using Project.Scripts.Enemy;
using UnityEngine;

namespace Project.Scripts.Enemies
{
    public class EnemyView : MonoBehaviour // возможно пока что удалить класс надо 
    {
        private Enemy[] _enemies;
        public EnemyHealth[] EnemyHealths { get; private set; }

        public void Initialize(Enemy[] enemies, EnemyHealth[] enemyHealths)
        {
            _enemies = enemies;
            EnemyHealths = enemyHealths;
        }
    }
}
