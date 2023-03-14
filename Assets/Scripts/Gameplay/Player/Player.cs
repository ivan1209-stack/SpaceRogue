using System;
using Gameplay.Health;
using Gameplay.Player.Movement;
using Gameplay.Player.Weapon;
using UnityEngine;

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
            Vector2 spawnPoint,
            PlayerViewFactory playerViewFactory, 
            PlayerMovementFactory playerMovementFactory, 
            PlayerTurningFactory playerTurningFactory,
            PlayerSurvivalFactory playerSurvivalFactory,
            PlayerWeaponFactory playerWeaponFactory)
        {
            PlayerView = playerViewFactory.Create(spawnPoint);
            _playerMovement = playerMovementFactory.Create(PlayerView);
            _playerTurning = playerTurningFactory.Create(PlayerView);
            _playerWeapon = playerWeaponFactory.Create(PlayerView);

            Survival = playerSurvivalFactory.Create();
        }

        public void Dispose()
        {
            PlayerDestroyed.Invoke();
            
            _playerMovement.Dispose();
            _playerTurning.Dispose();
            _playerWeapon.Dispose();
            
            UnityEngine.Object.Destroy(PlayerView);
        }

        private void OnDeath()
        {
            Dispose();
        }
    }
}