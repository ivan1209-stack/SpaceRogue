using System;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidMovement : IDisposable
    {
        protected AsteroidView View { get; private set; }
        protected AsteroidMoveConfig Config { get; private set; }
        protected Vector2 BasePoint { get; private set; }

        public AsteroidMovement(AsteroidView view, AsteroidMoveConfig config, Vector2 basePoint)
        {
            View = view;
            Config = config;
            BasePoint = basePoint;

            EntryPoint.SubscribeToFixedUpdate(SetAsteroidRotation);
        }

        public void Dispose()
        {
            EntryPoint.UnsubscribeFromUpdate(SetAsteroidRotation);
        }

        protected virtual void StartMovement(Vector3 direction) { }

        private void SetAsteroidRotation() => View.gameObject.transform.Rotate(Vector3.forward, Config.RotationSpeed);
    }
}