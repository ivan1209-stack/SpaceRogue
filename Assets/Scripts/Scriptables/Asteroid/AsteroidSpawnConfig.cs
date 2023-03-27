using Scriptables;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = nameof(AsteroidSpawnConfig), menuName = "Configs/Asteroids/" + nameof(AsteroidSpawnConfig))]
    public class AsteroidSpawnConfig : ScriptableObject
    {
        [field: SerializeField] public List<WeightConfig<AsteroidConfig>> AsteroidPrefabs { get; private set; }
    }
}