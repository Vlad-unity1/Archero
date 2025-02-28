using Project.Scripts.Weapons;
using UnityEngine;

namespace Project.Scripts.Player
{
    public class PlayerFactory
    {
        private readonly WeaponFactory _weaponFactory;
        private readonly GameObject _playerPrefab;

        public PlayerFactory(WeaponFactory weaponFactory, GameObject playerPrefab)
        {
            _weaponFactory = weaponFactory;
            _playerPrefab = playerPrefab;
        }

        public Player CreatePlayer(Vector3 spawnPosition, PlayerHealth health, Joystick joystick)
        {
            var playerObject = Object.Instantiate(_playerPrefab, spawnPosition, Quaternion.identity);
            var playerMovement = playerObject.GetComponent<PlayerMovement>();
            var playerView = playerObject.GetComponent<PlayerView>(); 
            var playerInput = new PlayerInputHandler(joystick);

            var weapon = _weaponFactory.CreateWeapon(playerObject);
            var player = new Player(health, 10, weapon, playerMovement, playerInput.Joystick); 
            playerMovement.Initialize(player, playerInput);
            playerView.Initialize(player); 
            player.SetWeapon(weapon);
            
            return player;
        }
    }
}