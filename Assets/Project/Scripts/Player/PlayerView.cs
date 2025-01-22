using Archer.PlayerStats;
using Arhcero.PlayerMovement;
using System.Collections;
using UnityEngine;

namespace Archero.PlayerView
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
        }

        private void HandlePlayerMove(bool isMoving)
        {
            if (isMoving)
            {
                StopAttacking();
            }
            else
            {
                StartAttacking();
            }
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

