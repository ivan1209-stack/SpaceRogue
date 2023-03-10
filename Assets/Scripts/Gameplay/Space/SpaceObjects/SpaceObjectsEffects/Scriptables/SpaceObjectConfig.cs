using UnityEngine;
using System.Collections.Generic;

namespace SpaceObjects
{
    [CreateAssetMenu(fileName = nameof(SpaceObjectConfig), menuName = "Configs/Space/" + nameof(SpaceObjectConfig))]
    public class SpaceObjectConfig : ScriptableObject
    {
        [field: SerializeField] public SpaceObjectView Prefab { get; private set; }

        [field: SerializeField, Min(0.1f), Header("Size")] public float MinSize { get; private set; } = 0.1f;
        [field: SerializeField, Min(1f)] public float MaxSize { get; private set; } = 1f;

        [field: SerializeField, Header("SpaceObjectEffects")] public List<SpaceObjectEffectConfig> Effects;
    }
}