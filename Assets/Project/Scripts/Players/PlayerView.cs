using Project.Scripts.PlayerModels;
using UnityEngine;

namespace Project.Scripts.Players
{
    public class PlayerView : MonoBehaviour
    {
        public Transform _weaponTransform;

        private PlayerMovement _playerMovement;
        private PlayerModel _player;

        public void Initialize(PlayerModel player, Transform weaponTransform)
        {
            _player = player;
            _weaponTransform = weaponTransform;
            _playerMovement = GetComponent<PlayerMovement>();
            _playerMovement.OnPlayerMove += HandlePlayerMove;
            _playerMovement.OnPlayerStop += HandlePlayerStop;
        }

        public void OnDestroy()
        {
            _playerMovement.OnPlayerMove -= HandlePlayerMove;
            _playerMovement.OnPlayerStop -= HandlePlayerStop;
        }

        private void HandlePlayerMove()
        {
            _player.StopAttacking();
        }

        private void HandlePlayerStop()
        {
            _player.StartAttack();
        }
    }
}