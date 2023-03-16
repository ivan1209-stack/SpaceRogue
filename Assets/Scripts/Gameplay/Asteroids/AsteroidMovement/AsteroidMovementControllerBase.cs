using Abstracts;
using UnityEngine;

namespace Asteroids
{
    public abstract class AsteroidMovementControllerBase : BaseController
    {
        protected AsteroidView View;
        protected AsteroidMovementModel Model;

        public AsteroidMovementControllerBase(AsteroidView view, AsteroidMoveConfig config)
        {
            View = view;
            Model = new(config);

            EntryPoint.SubscribeToUpdate(SetAsteroidRotation);
            AddController(this);
        }

        protected override void OnDispose()
        {
            Model = null;
            EntryPoint.UnsubscribeFromUpdate(SetAsteroidRotation);
        }

        protected abstract void StartMovement(Vector3 direction);

        private void SetAsteroidRotation() => View.gameObject.transform.Rotate(Vector3.forward, Model.RotationSpeed);
    }
}