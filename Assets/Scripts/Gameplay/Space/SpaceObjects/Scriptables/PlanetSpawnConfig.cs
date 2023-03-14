using System.Collections.Generic;
using Scriptables;
using UnityEngine;

namespace Gameplay.Space.SpaceObjects.Scriptables
{
    [CreateAssetMenu(fileName = nameof(PlanetSpawnConfig), menuName = "Configs/Space/" + nameof(PlanetSpawnConfig))]
    public sealed class PlanetSpawnConfig : ScriptableObject //TODO remove
    {
        [field: SerializeField] public List<WeightConfig<PlanetConfig>> WeightConfigs { get; private set; }
    }
}