using UnityEngine;
using Utilities.Mathematics;

namespace Asteroids
{
    public sealed class AsteroidRandomDirectedMovementController : AsteroidMovementControllerBase
    {
        public AsteroidRandomDirectedMovementController(AsteroidView view, AsteroidMoveConfig config) : base(view, config)
        {
            StartMovement(RandomPicker.PickRandomAngle(0, 360, new()));
        }

        protected override void StartMovement(Vector3 direction)
        {
            View.Rigidbody.AddForce(direction * Model.Acceleration);
        }
    }
}