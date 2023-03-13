using System;
using UnityEngine;

[Serializable]
public class AsteroidMoveConfig
{
    [field: SerializeField, Min(0)] public float StartingForce { get; private set; }
    [field: SerializeField] public AsteroidMoveType MoveType { get; private set; }
    [field: SerializeField, Tooltip("Rotation speed in radians"), Min(0)] public float RotationSpeed { get; private set; }
}
