using System;
using Gameplay.Player.Movement;
using Gameplay.Player.Weapon;
using Gameplay.Survival;

namespace Gameplay.Player
{
    public sealed class Player : IDisposable
    {
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerTurning _playerTurning;
        private readonly PlayerWeapon _playerWeapon;

        public event Action PlayerDestroyed = () => { };

        public PlayerView PlayerView { get; }
        public EntitySurvival Survival { get; }

        public Player(
            PlayerView playerView, 
            PlayerMovement playerMovement, 
            PlayerTurning playerTurning,
            EntitySurvival playerSurvival,
            PlayerWeapon playerWeapon)
        {
            PlayerView = playerView;
            _playerMovement = playerMovement;
            _playerTurning = playerTurning;
            _playerWeapon = playerWeapon;
            Survival = playerSurvival;
        }

        public void Dispose()
        {
            PlayerDestroyed.Invoke();
            
            _playerMovement.Dispose();
            _playerTurning.Dispose();
            _playerWeapon.Dispose();
            
            UnityEngine.Object.Destroy(PlayerView.gameObject);
        }

        private void OnDeath()
        {
            Dispose();
        }
    }
}