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
        private readonly PlayerMovementFactory _playerMovementFactory;
        private readonly UnitTurningMouseFactory _unitTurningMouseFactory;
        private readonly PlayerSurvivalFactory _playerSurvivalFactory;
        private readonly PlayerWeaponFactory _playerWeaponFactory;
        private readonly PlayerDashFactory _playerDashFactory;
        public event Action<PlayerSpawnedEventArgs> PlayerSpawned = _ => { };

        public PlayerFactory(
            PlayerViewFactory playerViewFactory,
            PlayerInput playerInput,
            UnitMovementConfig unitMovementConfig,
            UnitMovementModelFactory unitMovementModelFactory,
            PlayerMovementFactory playerMovementFactory,
            UnitTurningMouseFactory unitTurningMouseFactory,
            PlayerSurvivalFactory playerSurvivalFactory,
            PlayerWeaponFactory playerWeaponFactory,
            PlayerDashFactory playerDashFactory)
        {
            _playerViewFactory = playerViewFactory;
            _playerInput = playerInput;
            _unitMovementConfig = unitMovementConfig;
            _unitMovementModelFactory = unitMovementModelFactory;
            _playerMovementFactory = playerMovementFactory;
            _unitTurningMouseFactory = unitTurningMouseFactory;
            _playerSurvivalFactory = playerSurvivalFactory;
            _playerWeaponFactory = playerWeaponFactory;
            _playerDashFactory = playerDashFactory;
        }

        public override Player Create(Vector2 spawnPoint)
        {
            var playerView = _playerViewFactory.Create(spawnPoint);
            var model = _unitMovementModelFactory.Create(_unitMovementConfig);
            var unitMovement = _playerMovementFactory.Create(playerView, _playerInput, model);
            var unitTurningMouse = _unitTurningMouseFactory.Create(playerView, _playerInput, model);
            var playerWeapon = _playerWeaponFactory.Create(playerView);
            var playerSurvival = _playerSurvivalFactory.Create(playerView);
            var playerDash = _playerDashFactory.Create(playerView);
            
            PlayerSpawned.Invoke(new PlayerSpawnedEventArgs
            {
                Transform = playerView.transform
            });
            
            return new Player(playerView, unitMovement, unitTurningMouse, playerSurvival, playerWeapon, playerDash);
        }
    }
}