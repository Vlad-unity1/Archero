using UnityEngine;

namespace Project.Scripts.Enemies
{
    public class EnemyView : MonoBehaviour
    {
        public Transform[] _weaponTransform;
        private EnemyModel[] _enemyModel;

        public void Initialize(EnemyModel[] enemyModel, Transform[] transform)
        {
            _enemyModel = enemyModel;
            _weaponTransform = transform;
        }

        public EnemyModel[] GetEnemyModel()
        {
            return _enemyModel;
        }
    }
}
