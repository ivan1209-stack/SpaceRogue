using Gameplay.Factories;
using Gameplay.Player.Movement;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player
    {
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerTurning _playerTurning;
        
        public PlayerView PlayerView { get; }

        public Player(
            Vector2 spawnPoint,
            PlayerViewFactory playerViewFactory, 
            PlayerMovementFactory playerMovementFactory, 
            PlayerTurningFactory playerTurningFactory)
        {
            PlayerView = playerViewFactory.Create(spawnPoint);
            _playerMovement = playerMovementFactory.Create(PlayerView);
            _playerTurning = playerTurningFactory.Create(PlayerView);
        }
    }
}