using System.Collections.Generic;
using Scriptables;
using UnityEngine;

namespace Gameplay.Space.SpaceObjects.Scriptables
{
    public class SpaceObjectSpawnConfig
    {
        [field: SerializeField] public List<WeightConfig<SpaceObjectConfig>> SpaceObjectWeights { get; private set; }
    }
}