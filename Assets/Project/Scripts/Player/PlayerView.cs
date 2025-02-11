using System.Collections;
using UnityEngine;

namespace Project.Scripts.Player
{
    public class PlayerView : MonoBehaviour
    {
        private const float ATTACK_DELAY = 0.25f;
        [SerializeField] private PlayerMovement _playerMovement;

        private Player _player;
        private Coroutine _autoAttackCoroutine;

        public void Initialize(Player player)
        {
            _player = player;
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
            StopAttacking();
        }

        private void HandlePlayerStop()
        {
            StartAttacking();
        }

        private void StartAttacking()
        {
            _autoAttackCoroutine ??= StartCoroutine(AutoAttack());
        }

        private void StopAttacking()
        {
            if (_autoAttackCoroutine != null)
            {
                StopCoroutine(_autoAttackCoroutine);
                _autoAttackCoroutine = null;
            }
        }

        private IEnumerator AutoAttack()
        {
            while (true)
            {
                _player.Attack();
                yield return new WaitForSeconds(ATTACK_DELAY);
            }
        }
    }
}

