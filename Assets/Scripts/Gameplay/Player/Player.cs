using System;
using Gameplay.Movement;
using Gameplay.Player.Movement;
using Gameplay.Shooting;
using Gameplay.Survival;

namespace Gameplay.Player
{
    public sealed class Player : IDisposable
    {
        private readonly UnitMovement _unitMovement;
        private readonly UnitTurningMouse _unitTurningMouse;
        private readonly UnitWeapon _unitWeapon;

        public event Action PlayerDestroyed = () => { };

        public PlayerView PlayerView { get; }
        public EntitySurvival Survival { get; }

        public Player(
            PlayerView playerView, 
            UnitMovement unitMovement, 
            UnitTurningMouse unitTurningMouse,
            EntitySurvival playerSurvival,
            PlayerDash playerDash)
            UnitWeapon unitWeapon)
        {
            PlayerView = playerView;
            _unitMovement = unitMovement;
            _unitTurningMouse = unitTurningMouse;
            _unitWeapon = unitWeapon;
            Survival = playerSurvival;
            _playerDash = playerDash;

            Survival.EntityHealth.HealthReachedZero += OnDeath;
        }

        public void Dispose()
        {
            Survival.EntityHealth.HealthReachedZero -= OnDeath;
            
            PlayerDestroyed.Invoke();
            
            Survival.Dispose();
            _unitMovement.Dispose();
            _unitTurningMouse.Dispose();
            _playerDash.Dispose();
            _unitWeapon.Dispose();

            
            UnityEngine.Object.Destroy(PlayerView.gameObject);
        }

        private void OnDeath()
        {
            Dispose();
        }
    }
}