using Gameplay.Input;
using Gameplay.Player.Movement;
using System;
using UI.Game;
using UnityEngine;

namespace UI.Services
{
    public sealed class PlayerSpeedometerService : IDisposable
    {
        private readonly PlayerSpeedometerView _playerSpeedometerView;
        private readonly PlayerInput _playerInput;
        private readonly PlayerMovementFactory _movementFactory;

        private PlayerMovement _playerMovement;

        public PlayerSpeedometerService(PlayerInfoView playerInfoView, PlayerInput playerInput, PlayerMovementFactory movementFactory)
        {
            _playerSpeedometerView = playerInfoView.PlayerSpeedometerView;
            _playerInput = playerInput;
            _movementFactory = movementFactory;

            _playerSpeedometerView.Hide();

            _movementFactory.PlayerMovementCreated += OnPlayerMovementCreated;
        }

        public void Dispose()
        {
            _movementFactory.PlayerMovementCreated -= OnPlayerMovementCreated;
            _playerInput.VerticalAxisInput -= UpdateSpeedometer;
        }

        private void OnPlayerMovementCreated(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;

            _playerSpeedometerView.Show();
            _playerSpeedometerView.Init(GetSpeedometerTextValue(_playerMovement.CurrentSpeed, _playerMovement.MaxSpeed));

            _playerInput.VerticalAxisInput += UpdateSpeedometer;
        }

        private void UpdateSpeedometer(float obj)
        {
            _playerSpeedometerView.UpdateText(GetSpeedometerTextValue(_playerMovement.CurrentSpeed, _playerMovement.MaxSpeed));
        }

        private string GetSpeedometerTextValue(float currentSpeed, float maximumSpeed)
        {
            return currentSpeed switch
            {
                < 0 => "R",
                _ => $"SPD: {Mathf.RoundToInt(currentSpeed / maximumSpeed * 100)}"
            };
        }
    }
}