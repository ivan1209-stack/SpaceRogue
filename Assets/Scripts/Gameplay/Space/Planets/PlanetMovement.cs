using System;
using Services;
using UnityEngine;
using Gameplay.Space.SpaceObjects.Scriptables;
using Utilities.Mathematics;
using Random = System.Random;

namespace Gameplay.Space.Planets
{
    public class PlanetMovement : IDisposable
    {
        private readonly PlanetView _view;
        private readonly Updater _updater;
        private readonly Rigidbody2D _planetRigidbody;
        private readonly float _speed;
        protected readonly Random _random = new();
        private readonly Transform _spaceObjectTransform;
        private float _speedMultiplier = 0.1f;
        private float _angle = 0f;
        private Transform _axis;
        private bool _isMovingRetrograde;

        public PlanetMovement(PlanetView view, Updater updater, PlanetConfig planetConfig, Transform spaceObjectTransform)
        {
            _view = view;
            _updater = updater;
            _spaceObjectTransform = spaceObjectTransform;
            _planetRigidbody = _view.GetComponent<Rigidbody2D>();
            _speed = RandomPicker.PickRandomBetweenTwoValues(planetConfig.MinSpeed, planetConfig.MaxSpeed);
            _axis = _planetRigidbody.transform;
            _speed = _speed / _planetRigidbody.mass * _speedMultiplier;
            _isMovingRetrograde = RandomPicker.TakeChance(planetConfig.RetrogradeMovementChance, _random);
            _updater.SubscribeToUpdate(Move);
        }

        public void Dispose()
        {
            _updater.UnsubscribeFromUpdate(Move);
        }


        private void Move()
        {
                _axis.RotateAround(_spaceObjectTransform.position,
                _isMovingRetrograde ? Vector3.forward : Vector3.back,
                _speed);
                
                rotateRigidBodyAroundPointBy(_planetRigidbody, _spaceObjectTransform.position, _planetRigidbody.transform.position, _angle);
        }
        public void rotateRigidBodyAroundPointBy(Rigidbody2D rb, Vector3 origin, Vector3 axis, float angle)
        {

            Quaternion q = Quaternion.AngleAxis(angle, axis);
            rb.MovePosition(q * (rb.transform.position - origin) + origin);
            rb.MoveRotation(rb.transform.rotation * q);
        }
    }
}