using Archer.PlayerStats;
using UnityEngine;

namespace Arhcero.PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        public delegate void PlayerMovementHandler(bool isMoving);
        public event PlayerMovementHandler OnPlayerMove;

        [SerializeField] private Joystick _joystick;
        [SerializeField] private CharacterController _characterController;

        private Player _player;

        public void Intialize(Player player)
        {
            _player = player;
        }

        public void Move()
        {
            Vector3 moveDirection = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical).normalized;
            bool isMoving = moveDirection.magnitude > 0;
            _characterController.Move(moveDirection * _player.Speed * Time.deltaTime);

            if (moveDirection != Vector3.zero)
            {
                transform.forward = moveDirection;
            }

            if (isMoving)
            {
                OnPlayerMove?.Invoke(true);
            }
            else
            {
                OnPlayerMove?.Invoke(false);
            }
        }
    }
}