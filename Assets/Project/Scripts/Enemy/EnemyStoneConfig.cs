using UnityEngine;

namespace Project.Scripts.Enemy
{
    [CreateAssetMenu(fileName = "StoneEnemy", menuName = "Enemy/StoneEnemyConfig", order = 60)]
    public class EnemyStoneConfig : EnemyConfig
    {
        public float AttackDelay = 2.0f;
    }
}