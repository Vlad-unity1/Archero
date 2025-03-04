using UnityEngine;

namespace Project.Scripts.Enemies
{
    public class EnemyView : MonoBehaviour
    {
        public Transform[] WeaponTransform;
        private EnemyModel _enemyModel;

        public void Initialize(EnemyModel enemyModel, Transform[] transform)
        {
            _enemyModel = enemyModel;
            WeaponTransform = transform;
        }

        public EnemyModel GetEnemyModel()
        {
            return _enemyModel;
        }
    }
}
