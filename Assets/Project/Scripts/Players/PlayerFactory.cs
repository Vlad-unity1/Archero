using Project.Scripts.Enemy;
using Project.Scripts.Player;
using Project.Scripts.PlayerModels;
using Project.Scripts.Weapons;
using UnityEngine;

namespace Project.Scripts.Players
{
    public class PlayerFactory : MonoBehaviour
    {
        [SerializeField] private WeaponFactory _weaponFactory;
        [SerializeField] private PlayerMovement _playerPrefab;

        public PlayerModel CreatePlayer(Transform spawnPosition, int initialHealth, Joystick joystick)
        {
            var playerObject = Object.Instantiate(_playerPrefab, spawnPosition.position, Quaternion.identity);
            var playerMovement = playerObject.GetComponent<PlayerMovement>();
            var playerInput = new PlayerInputHandler(joystick);

            var weapon = _weaponFactory.CreateWeapon(playerMovement.weaponTransformPrefab);
            var health = new Health(initialHealth);
            var player = new PlayerModel(health, 10, weapon, playerMovement, playerInput.Joystick);

            playerMovement.Initialize(player, playerInput);
            player.SetWeapon(weapon);
            
            return player;
        }
    }
}