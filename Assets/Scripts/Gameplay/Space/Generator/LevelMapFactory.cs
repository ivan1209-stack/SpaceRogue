using Gameplay.Space.SpaceObjects.Scriptables;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Gameplay.Space.Generator
{
    public sealed class LevelMapFactory : PlaceholderFactory<SpaceView, SpaceConfig, int[,], int[,], LevelMap>
    {
    }
}