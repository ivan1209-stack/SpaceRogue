using System;
using Gameplay.Movement;
using Gameplay.Player.Movement;
using Gameplay.Player.Weapon;
using Gameplay.Survival;

namespace Gameplay.Player
{
    public sealed class Player : IDisposable
    {
        private readonly UnitMovement _unitMovement;
        private readonly PlayerTurning _playerTurning;
        private readonly PlayerWeapon _playerWeapon;

        public event Action PlayerDestroyed = () => { };

        public PlayerView PlayerView { get; }
        public EntitySurvival Survival { get; }

        public Player(
            PlayerView playerView, 
            UnitMovement unitMovement, 
            PlayerTurning playerTurning,
            EntitySurvival playerSurvival,
            PlayerWeapon playerWeapon)
        {
            PlayerView = playerView;
            _unitMovement = unitMovement;
            _playerTurning = playerTurning;
            _playerWeapon = playerWeapon;
            Survival = playerSurvival;

            Survival.EntityHealth.HealthReachedZero += OnDeath;
        }

        public void Dispose()
        {
            Survival.EntityHealth.HealthReachedZero -= OnDeath;
            
            PlayerDestroyed.Invoke();
            
            Survival.Dispose();
            _unitMovement.Dispose();
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