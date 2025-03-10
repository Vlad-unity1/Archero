using System;
using Project.Scripts.Player;
using Project.Scripts.PlayerModels;
using UnityEngine;

namespace Project.Scripts.Players
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] public Transform weaponTransformPrefab;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private float _enemyDetectionRadius = 50f;
        private bool _isMoving = false;

        private PlayerInputHandler _inputHandler;
        private PlayerModel _player;
        private Transform _nearestEnemy;

        public void Initialize(PlayerModel player, PlayerInputHandler inputHandler)
        {
            _player = player;
            _inputHandler = inputHandler;
        }

        public void Move()
        {
            Vector3 moveDirection = _inputHandler.GetInputDirection();
            _characterController.Move(moveDirection * (_player.Speed * Time.deltaTime));
            bool isCurrentlyMoving = moveDirection != Vector3.zero;

            if (isCurrentlyMoving && !_isMoving)
            {
                _player.StopAttacking();
            }
            else if (!isCurrentlyMoving && _isMoving)
            {
                _player.StartAttack();
                RotateToEnemy();
            }

            _isMoving = isCurrentlyMoving;

            if (isCurrentlyMoving)
            {
                transform.forward = moveDirection;
            }
        }

        public void RotateToEnemy()
        {
            _nearestEnemy = FindNearestEnemy();
            if (_nearestEnemy == null)
            {
                return;
            }

            Vector3 directionToEnemy = (_nearestEnemy.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(directionToEnemy);
            transform.rotation = targetRotation;
        }



        private Transform FindNearestEnemy()
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, _enemyDetectionRadius, _enemyLayer);
            Debug.Log($"Найдено врагов: {enemies.Length}");
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