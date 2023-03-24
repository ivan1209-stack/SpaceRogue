using UnityEngine;
using Utilities.Mathematics;

namespace Asteroids
{
    public sealed class AsteroidRandomDirectedMovement : AsteroidMovement
    {
        public AsteroidRandomDirectedMovement(AsteroidView view, AsteroidMoveConfig config, Vector2 basePoint) : base(view, config, basePoint)
        {
            StartMovement(RandomPicker.PickRandomAngle(0, 360));
        }

        protected override void StartMovement(Vector3 direction)
        {
            View.Rigidbody.AddForce(direction * Config.StartingForce, ForceMode2D.Impulse);
        }
    }
}