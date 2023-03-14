using System.Collections.Generic;
using Scriptables;
using UnityEngine;

namespace Gameplay.Space.SpaceObjects.Scriptables
{
    [CreateAssetMenu(fileName = nameof(StarSpawnConfig), menuName = "Configs/Space/" + nameof(StarSpawnConfig))]
    public sealed class StarSpawnConfig : ScriptableObject
    {
        [field: SerializeField] public List<WeightConfig<StarConfig>> WeightConfigs { get; private set; }
    }
}