using System;
using Gameplay.Input;
using Gameplay.Movement;
using UnityEngine;

namespace Gameplay.Player.Movement
{
    public class PlayerMovement : IDisposable
    {
        private readonly PlayerInput _playerInput;
        private readonly UnitMovementModel _model;
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;

        public float CurrentSpeed => _model.CurrentSpeed;
        public float MaxSpeed => _model.MaxSpeed;

        public PlayerMovement(PlayerView playerView, PlayerInput playerInput, UnitMovementModelFactory movementModelFactory, UnitMovementConfig movementConfig)
        {
            _playerInput = playerInput;
            _model = movementModelFactory.Create(movementConfig);
            _rigidbody = playerView.GetComponent<Rigidbody2D>();
            _transform = playerView.transform;

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
    }
}