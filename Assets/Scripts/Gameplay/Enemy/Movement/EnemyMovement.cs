using Gameplay.Movement;
using System;
using UnityEngine;

namespace Gameplay.Enemy.Movement
{
    public sealed class EnemyMovement : IDisposable
    {
        private readonly Transform _transform;
        private readonly Rigidbody2D _rigidbody;
        private readonly EnemyInput _enemyInput;
        private readonly UnitMovementModel _model;

        public EnemyMovement(
            EnemyView enemyView,
            EnemyInput enemyInput,
            UnitMovementModel model)
        {
            _rigidbody = enemyView.GetComponent<Rigidbody2D>();
            _transform = enemyView.transform;
            _enemyInput = enemyInput;
            _model = model;

            _enemyInput.VerticalAxisInput += HandleVerticalInput;
        }

        public void Dispose()
        {
            _enemyInput.VerticalAxisInput -= HandleVerticalInput;
        }

        private void HandleVerticalInput(float newInputValue)
        {
            if (newInputValue != 0)
            {
                _model.Accelerate(newInputValue > 0);
            }
            
            float currentSpeed = _model.CurrentSpeed;
            float maxSpeed = _model.MaxSpeed;
            
            if (currentSpeed != 0)
            {
                var forwardDirection = _transform.TransformDirection(Vector3.up);
                _rigidbody.AddForce(forwardDirection.normalized * currentSpeed, ForceMode2D.Force);
            }
            
            if (_rigidbody.velocity.sqrMagnitude > maxSpeed * maxSpeed)
            {
                Vector3 velocity = _rigidbody.velocity.normalized * maxSpeed;
                _rigidbody.velocity = velocity;
            }

            if (newInputValue == 0 && currentSpeed < _model.StoppingSpeed && currentSpeed > -_model.StoppingSpeed)
            {
                _model.StopMoving();
            }
        }
    }
}