using UnityEngine;
using System.Collections.Generic;

namespace Scriptables.Space
{
    public class SpaceObjectSpawnConfig
    {
        [field: SerializeField] public List<WeightConfig<SpaceObjectConfig>> SpaceObjectWeights { get; private set; }
    }
}