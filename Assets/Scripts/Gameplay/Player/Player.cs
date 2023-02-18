using Gameplay.Factories;
using Gameplay.Player.Movement;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player
    {
        private readonly PlayerMovement _playerMovement;
        private readonly PlayerTurning _playerTurning;
        private readonly PlayerView _playerView;

        public Player(
            Vector2 spawnPoint,
            PlayerViewFactory playerViewFactory, 
            PlayerMovement playerMovement, 
            PlayerTurning playerTurning)
        {
            _playerMovement = playerMovement;
            _playerTurning = playerTurning;
            _playerView = playerViewFactory.Create(spawnPoint);
        }
    }
}