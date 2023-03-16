using UnityEngine;

namespace Asteroids
{
    public class AsteroidMovementModel
    {
        public float Acceleration { get; private set; }
        public AsteroidMoveType MoveType { get; private set; }
        public float RotationSpeed { get; private set; }
        public Vector3 BasePoint { get; private set; }

        public AsteroidMovementModel(AsteroidMoveConfig config)
        {
            Acceleration = config.StartingForce;
            MoveType = config.MoveType;
            RotationSpeed = config.RotationSpeed;
        }

        public void SetAsteroidMoveType(AsteroidMoveType moveType) => MoveType = moveType;
        public void SetBasePoint(Vector3 newBasePoint) => BasePoint = newBasePoint;
    }
}