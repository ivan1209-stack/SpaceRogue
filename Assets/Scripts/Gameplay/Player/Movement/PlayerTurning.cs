using System;
using Gameplay.Camera;
using Gameplay.Input;
using Gameplay.Movement;
using UnityEngine;
using Utilities.Unity;

namespace Gameplay.Player.Movement
{
    public sealed class PlayerTurning : IDisposable
    {
        private readonly PlayerInput _playerInput;
        private readonly UnitMovementModel _model;
        private readonly Rigidbody2D _rigidbody;
        private readonly Transform _transform;
        private readonly UnityEngine.Camera _camera;
        
        private Vector3 _currentDirection;
        private float _lastTurnRate;

        public PlayerTurning(PlayerView playerView, PlayerInput playerInput, UnitMovementModelFactory movementModelFactory, UnitMovementConfig movementConfig, CameraView cameraView)
        {
            _playerInput = playerInput;
            _model = movementModelFactory.Create(movementConfig);
            _rigidbody = playerView.GetComponent<Rigidbody2D>();
            _transform = playerView.transform;
            _camera = cameraView.GetComponent<UnityEngine.Camera>();

            _playerInput.MousePositionInput += HandleHorizontalMouseInput;
        }

        public void Dispose()
        {
            _playerInput.MousePositionInput -= HandleHorizontalMouseInput;
        }

        private void HandleHorizontalMouseInput(Vector3 newMousePositionInput)
        {
            var mousePosition = _camera.ScreenToWorldPoint(newMousePositionInput);
            mousePosition.z = 0;

            var direction = (mousePosition - _transform.position).normalized;
            _currentDirection = _transform.TransformDirection(Vector3.up);
            float angle = Vector2.SignedAngle(direction, _currentDirection);

            Quaternion newRotation;
            if (UnityHelper.Approximately(angle, 0, Mathf.Abs(_lastTurnRate)))
            {
                _model.StopTurning();
                _lastTurnRate = _model.StartingTurnSpeed;

                newRotation = angle > 0 
                    ? GetNewRotation(-angle, Vector3.forward) 
                    : GetNewRotation(angle, Vector3.back);
                
                _rigidbody.MoveRotation(newRotation);
                _rigidbody.angularVelocity = 0;
                return;
            }

            if (angle > 0)
            {
                _model.Turn(true);
                newRotation = GetNewRotation(_model.CurrentTurnRate, Vector3.forward);
            }
            else
            {
                _model.Turn(false);
                newRotation = GetNewRotation(-_model.CurrentTurnRate, Vector3.back);
            }

            _lastTurnRate = _model.CurrentTurnRate;
            _rigidbody.MoveRotation(newRotation);
        }

        private Quaternion GetNewRotation(float angle, Vector3 axis)
        {
            return _transform.rotation * Quaternion.AngleAxis(angle, axis);
        }
    }
}