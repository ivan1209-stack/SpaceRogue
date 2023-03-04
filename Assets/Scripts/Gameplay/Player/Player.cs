using System;
using Gameplay.Factories;
using Gameplay.Health;
using Gameplay.Player.Inventory;
using Gameplay.Player.Movement;
using UnityEngine;

namespace Gameplay.Player
{
    public sealed class Player : IDisposable
    {
        private readonly PlayerInventory _playerInventory;
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerTurning _playerTurning;

        public event Action PlayerDestroyed = () => { };

        public PlayerView PlayerView { get; }
        public EntitySurvival Survival { get; }

        public Player(
            Vector2 spawnPoint,
            PlayerViewFactory playerViewFactory, 
            PlayerMovementFactory playerMovementFactory, 
            PlayerTurningFactory playerTurningFactory,
            PlayerInventory playerInventory,
            PlayerSurvivalFactory playerSurvivalFactory)
        {
            _playerInventory = playerInventory;
            
            PlayerView = playerViewFactory.Create(spawnPoint);
            _playerMovement = playerMovementFactory.Create(PlayerView);
            _playerTurning = playerTurningFactory.Create(PlayerView);

            Survival = playerSurvivalFactory.Create();
        }

        public void Dispose()
        {
            PlayerDestroyed.Invoke();
            
            _playerInventory.Dispose();
            _playerMovement.Dispose();
            _playerTurning.Dispose();
            
            UnityEngine.Object.Destroy(PlayerView);
        }

        private void OnDeath()
        {
            Dispose();
        }
    }
}