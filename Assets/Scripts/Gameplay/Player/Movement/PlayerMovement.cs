using System;
using Gameplay.Input;
using Gameplay.Movement;
using UI.Game;
using UI.Services;
using UnityEngine;

namespace Gameplay.Player.Movement
{
    public class PlayerMovement : IDisposable
    {
        private readonly PlayerInput _playerInput;
        private readonly UnitMovementModel _model;
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;

        private readonly PlayerSpeedometerView _speedometerView;

        public float CurrentSpeed => _model.CurrentSpeed;
        public float MaxSpeed => _model.MaxSpeed;

        public PlayerMovement(PlayerView playerView, PlayerInput playerInput, PlayerInfoService playerInfoService, UnitMovementModelFactory movementModelFactory, UnitMovementConfig movementConfig)
        {
            _playerInput = playerInput;
            _model = movementModelFactory.Create(movementConfig);
            _rigidbody = playerView.GetComponent<Rigidbody2D>();
            _transform = playerView.transform;

            _speedometerView = playerInfoService.PlayerSpeedometerView;
            _speedometerView.Init(GetSpeedometerTextValue(_model.CurrentSpeed, _model.MaxSpeed));

            _playerInput.VerticalAxisInput += HandleVerticalInput;
        }

        public void Dispose()
        {
            _playerInput.VerticalAxisInput -= HandleVerticalInput;
        }

        private void HandleVerticalInput(float newInputValue)
        {
            if (newInputValue != 0)
            {
                _model.Accelerate(newInputValue > 0);
            }

            _speedometerView.UpdateText(GetSpeedometerTextValue(_model.CurrentSpeed, _model.MaxSpeed));

            if (CurrentSpeed != 0)
            {
                var forwardDirection = _transform.TransformDirection(Vector3.up);
                
                _rigidbody.AddForce(forwardDirection.normalized * CurrentSpeed, ForceMode2D.Force);
            }
            
            if (_rigidbody.velocity.sqrMagnitude > MaxSpeed * MaxSpeed)
            {
                Vector3 velocity = _rigidbody.velocity.normalized * MaxSpeed;
                _rigidbody.velocity = velocity;
            }

            if (newInputValue == 0 && CurrentSpeed < _model.StoppingSpeed && CurrentSpeed > -_model.StoppingSpeed)
            {
                _model.StopMoving();
            }
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