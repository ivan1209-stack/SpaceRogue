using System;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = nameof(AsteroidMoveConfig), menuName = "Configs/Asteroids/" + nameof(AsteroidMoveConfig))]
    public class AsteroidMoveConfig : ScriptableObject
    {
        [field: SerializeField, Min(0.0f)] public float StartingForce { get; private set; }
        [field: SerializeField] public AsteroidMoveType MoveType { get; private set; }
        [field: SerializeField, Tooltip("Rotation speed in radians"), Min(0)] public float RotationSpeed { get; private set; }
    }
}
