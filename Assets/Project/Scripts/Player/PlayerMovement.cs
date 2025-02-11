using System;
using UnityEngine;

namespace Project.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public event Action OnPlayerMove;
        public event Action OnPlayerStop;

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _rotationSpeed = 720f;
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private float _enemyDetectionRadius = 15f;

        private PlayerInputHandler _inputHandler;
        private Player _player;
        private Transform _nearestEnemy;

        public void Initialize(Player player, PlayerInputHandler inputHandler)
        {
            _player = player;
            _inputHandler = inputHandler;
        }

        public void Move()
        {
            Vector3 moveDirection = _inputHandler.GetInputDirection();
            _characterController.Move(moveDirection * (_player.Speed * Time.deltaTime));

            if (moveDirection != Vector3.zero)
            {
                transform.forward = moveDirection;
                OnPlayerMove?.Invoke();
            }
            else
            {
                OnPlayerStop?.Invoke();
                RotateToEnemy();
            }
        }

        public void RotateToEnemy()
        {
            _nearestEnemy = FindNearestEnemy();
            if (_nearestEnemy == null) return;

            Vector3 directionToEnemy = (_nearestEnemy.position - transform.position).normalized;
            directionToEnemy.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(directionToEnemy);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }

        private Transform FindNearestEnemy()
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, _enemyDetectionRadius, _enemyLayer);
            Transform closestEnemy = null;
            float minDistance = Mathf.Infinity;

            foreach (Collider enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = enemy.transform;
                }
            }
            return closestEnemy;
        }
    }
}