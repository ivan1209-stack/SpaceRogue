using UnityEngine;
using System.Collections.Generic;

namespace SpaceObjects
{
    [CreateAssetMenu(fileName = nameof(SpaceObjectConfig), menuName = "Configs/Space/" + nameof(SpaceObjectConfig))]
    public class SpaceObjectConfig : ScriptableObject
    {
        [field: SerializeField, Min(5f), Header("Size")] public float MinSize { get; private set; } = 5f;
        [field: SerializeField, Min(5.1f)] public float MaxSize { get; private set; } = 5.1f;

        [field: SerializeField, Header("SpaceObjectEffects")] public List<SpaceObjectEffectConfig> Effects;
    }
}