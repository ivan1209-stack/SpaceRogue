using UnityEngine.Tilemaps;
using Zenject;

namespace Gameplay.Space.Generator
{
    public sealed class SpawnPointsFinderFactory : PlaceholderFactory<int[,], Tilemap, SpawnPointsFinder>
    {
    }
}