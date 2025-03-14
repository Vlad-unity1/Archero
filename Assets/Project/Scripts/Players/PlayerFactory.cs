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

        public PlayerModel CreatePlayer(SpawnPointPlayerScene spawnPosition, int initialHealth, Joystick joystick)
        {
            PlayerMovement playerMovement = Object.Instantiate(_playerPrefab, spawnPosition.transform.position, Quaternion.identity);
            var playerInput = new PlayerInputHandler(joystick);

            var weapon = _weaponFactory.CreateWeapon(playerMovement.weaponTransformPrefab);
            var health = new Health(initialHealth, playerMovement.gameObject);
            var player = new PlayerModel(health, 10, weapon, playerMovement, playerInput.Joystick);

            playerMovement.Initialize(player, playerInput, health);
            player.SetWeapon(weapon);
            
            return player;
        }
    }
}