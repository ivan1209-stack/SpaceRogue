using Asteroids;
using System;
using UnityEngine;
using Zenject;

public class AsteroidMovementFactory : PlaceholderFactory<AsteroidMoveConfig, AsteroidView, Vector2, AsteroidMovement>
{
    public override AsteroidMovement Create(AsteroidMoveConfig config, AsteroidView view, Vector2 basePoint)
    {
        return config.MoveType switch
        {
            AsteroidMoveType.None => throw new ArgumentException("Asteroid move type not set"),
            AsteroidMoveType.RandomDirected => new AsteroidRandomDirectedMovement(view, config, basePoint),
            AsteroidMoveType.Targeting => throw new InvalidOperationException("No movement behaviour for Targeting move type"),
            AsteroidMoveType.Escaping => throw new InvalidOperationException("No movement behaviour for Escaping move type"),
            _ => throw new ArgumentOutOfRangeException("Invalid asteroid move type set"),
        };
    }
}
