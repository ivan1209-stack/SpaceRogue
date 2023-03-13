using Abstracts;
using Gameplay.Shooting.Scriptables;
using UnityEngine;

namespace Gameplay.Shooting
{
    public sealed class ProjectileSpawnParams
    {
        public Vector2 Position { get; }
        public Quaternion Rotation { get; }
        public UnitType UnitType { get; }
        public ProjectileConfig Config { get; }

        public ProjectileSpawnParams(Vector2 position, Quaternion rotation, UnitType unitType, ProjectileConfig config)
        {
            Position = position;
            Rotation = rotation;
            UnitType = unitType;
            Config = config;
        }

        public void Deconstruct(out Vector2 position, out Quaternion rotation, out ProjectileConfig config, out UnitType unitType)
        {
            position = Position;
            rotation = Rotation;
            config = Config;
            unitType = UnitType;
        }
    }
}