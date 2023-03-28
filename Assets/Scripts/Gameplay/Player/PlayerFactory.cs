using System;
using Gameplay.Events;
using Gameplay.Input;
using Gameplay.Movement;
using Gameplay.Player.Movement;
using Gameplay.Player.Weapon;
using UnityEngine;
using Zenject;

namespace Gameplay.Player
{
    public sealed class PlayerFactory : PlaceholderFactory<Vector2, Player>
    {
        private readonly PlayerViewFactory _playerViewFactory;
        private readonly PlayerInput _playerInput;
        private readonly UnitMovementConfig _unitMovementConfig;
        private readonly UnitMovementModelFactory _unitMovementModelFactory;
        private readonly UnitMovementFactory _unitMovementFactory;
        private readonly PlayerTurningFactory _playerTurningFactory;
        private readonly PlayerSurvivalFactory _playerSurvivalFactory;
        private readonly PlayerWeaponFactory _playerWeaponFactory;
        public event Action<PlayerSpawnedEventArgs> PlayerSpawned = _ => { };

        public PlayerFactory(
            PlayerViewFactory playerViewFactory,
            PlayerInput playerInput,
            UnitMovementConfig unitMovementConfig,
            UnitMovementModelFactory unitMovementModelFactory,
            UnitMovementFactory unitMovementFactory,
            PlayerTurningFactory playerTurningFactory,
            PlayerSurvivalFactory playerSurvivalFactory,
            PlayerWeaponFactory playerWeaponFactory)
        {
            _playerViewFactory = playerViewFactory;
            _playerInput = playerInput;
            _unitMovementConfig = unitMovementConfig;
            _unitMovementModelFactory = unitMovementModelFactory;
            _unitMovementFactory = unitMovementFactory;
            _playerTurningFactory = playerTurningFactory;
            _playerSurvivalFactory = playerSurvivalFactory;
            _playerWeaponFactory = playerWeaponFactory;
        }

        public override Player Create(Vector2 spawnPoint)
        {
            var playerView = _playerViewFactory.Create(spawnPoint);
            var model = _unitMovementModelFactory.Create(_unitMovementConfig);
            var unitMovement = _unitMovementFactory.Create(playerView, _playerInput, model);

            var playerTurning = _playerTurningFactory.Create(playerView);
            var playerWeapon = _playerWeaponFactory.Create(playerView);
            var playerSurvival = _playerSurvivalFactory.Create();
            
            PlayerSpawned.Invoke(new PlayerSpawnedEventArgs
            {
                Transform = playerView.transform
            });
            
            return new Player(playerView, unitMovement, playerTurning, playerSurvival, playerWeapon);
        }
    }
}