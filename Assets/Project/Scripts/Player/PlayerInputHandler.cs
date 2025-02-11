using UnityEngine;

namespace Project.Scripts.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;

        public Vector3 GetInputDirection()
        {
            return new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical).normalized;
        }
    }
}