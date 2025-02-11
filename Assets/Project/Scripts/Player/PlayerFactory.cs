using Project.Scripts.Weapon;

namespace Project.Scripts.Player
{
    public class PlayerFactory
    {
        private readonly WeaponFactory _weaponFactory;
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerInputHandler _playerInputHandler;

        public PlayerFactory(WeaponFactory weaponFactory, PlayerMovement playerMovement, PlayerInputHandler playerInputHandler)
        {
            _weaponFactory = weaponFactory;
            _playerMovement = playerMovement;
            _playerInputHandler = playerInputHandler;
        }

        public Player CreatePlayer(PlayerHealth health)
        {
            var weapon = _weaponFactory.CreateWeapon();
            var player = new Player(health, 10, weapon, _playerMovement);
            _playerMovement.Initialize(player, _playerInputHandler);
            player.SetWeapon(weapon);
            return player;
        }
    }
}