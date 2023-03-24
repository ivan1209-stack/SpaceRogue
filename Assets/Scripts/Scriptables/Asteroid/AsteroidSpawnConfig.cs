using Scriptables;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = nameof(AsteroidSpawnConfig), menuName = "Configs/AsteroidObjects/" + nameof(AsteroidSpawnConfig))]
    public class AsteroidSpawnConfig : ScriptableObject
    {
        [field: SerializeField] public int StartingAsteroidsInSpaceNumber { get; private set; }
        [field: SerializeField] public List<WeightConfig<AsteroidConfig>> AsteroidPrefabs { get; private set; }
    }
}