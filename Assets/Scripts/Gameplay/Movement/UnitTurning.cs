using Abstracts;
using Gameplay.Camera;
using System;
using UnityEngine;
using Utilities.Unity;

namespace Gameplay.Movement
{
    public sealed class UnitTurning : IDisposable
    {
        private readonly UnityEngine.Camera _camera;
        private readonly Transform _transform;
        private readonly Rigidbody2D _rigidbody;
        private readonly IUnitTurningHandleInput _turningHandleInput;
        private readonly IUnitTurningMouseInput _turningMouseInput;
        private readonly UnitMovementModel _model;

        private float _lastTurnRate;

        public UnitTurning(
            CameraView cameraView,
            UnitView unitView,
            IUnitTurningInput turningInput,
            UnitMovementModel model)
        {
            _camera = cameraView.GetComponent<UnityEngine.Camera>();
            _transform = unitView.transform;
            _rigidbody = unitView.GetComponent<Rigidbody2D>();

            if (turningInput is IUnitTurningHandleInput handleInput)
            {
                _turningHandleInput = handleInput;
                _turningHandleInput.HorizontalAxisInput += HandleHorizontalInput;
            }
            else if (turningInput is IUnitTurningMouseInput mouseInput)
            {
                _turningMouseInput = mouseInput;
                _turningMouseInput.MousePositionInput += HandleHorizontalMouseInput;
            }

            _model = model;
        }

        public void Dispose()
        {
            if (_turningHandleInput != null)
            {
                _turningHandleInput.HorizontalAxisInput -= HandleHorizontalInput; 
            }

            if(_turningMouseInput != null)
            {
                _turningMouseInput.MousePositionInput -= HandleHorizontalMouseInput;
            }
        }
        
        private void HandleHorizontalInput(float newInputValue)
        {
            Quaternion newRotation = Quaternion.identity;
            switch (newInputValue)
            {
                case 0:
                    _model.StopTurning();
                    newRotation = _transform.rotation;
                    break;
                case < 0:
                    _model.Turn(true);
                    newRotation = _transform.rotation * Quaternion.AngleAxis(_model.CurrentTurnRate * newInputValue, Vector3.forward);
                    break;
                case > 0:
                    _model.Turn(false);
                    newRotation = _transform.rotation * Quaternion.AngleAxis(_model.CurrentTurnRate * newInputValue, Vector3.back);
                    break;
            }
            _rigidbody.MoveRotation(newRotation);
        }

        private void HandleHorizontalMouseInput(Vector3 newMousePositionInput)
        {
            var mousePosition = _camera.ScreenToWorldPoint(newMousePositionInput);
            mousePosition.z = 0;

            var direction = (mousePosition - _transform.position).normalized;
            var currentDirection = _transform.TransformDirection(Vector3.up);
            float angle = Vector2.SignedAngle(direction, currentDirection);

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