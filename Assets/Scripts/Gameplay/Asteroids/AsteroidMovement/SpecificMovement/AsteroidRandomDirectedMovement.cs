using UnityEngine;
using Utilities.Mathematics;

namespace Asteroids
{
    public sealed class AsteroidRandomDirectedMovement : IMovementBehaviour
    {
        private readonly AsteroidView _view;

        private AsteroidMoveConfig _config;

        public AsteroidRandomDirectedMovement(AsteroidView view, AsteroidMoveConfig config)
        {
            _view = view;
            _config = config;
        }

        public void Dispose()
        {
            _config = null;
        }

        public void StartMovement()
        {
            var rigidbody = _view.GetComponent<Rigidbody2D>();
            var direction = RandomPicker.PickRandomAngle(0, 360);
            rigidbody.AddForce(direction * _config.StartingSpeed, ForceMode2D.Impulse);
        }
    }
}