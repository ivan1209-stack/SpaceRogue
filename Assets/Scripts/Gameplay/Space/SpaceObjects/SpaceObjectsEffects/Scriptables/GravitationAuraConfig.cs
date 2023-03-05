using UnityEngine;

namespace SpaceObjects
{
    [CreateAssetMenu(fileName = nameof(GravitationAuraConfig), menuName = "Configs/Space/" + nameof(GravitationAuraConfig))]
    public class GravitationAuraConfig : SpaceObjectEffectConfig
    {
        [field: SerializeField] public GravityAuraView Prefab { get; private set; }
        [field: SerializeField, Range(1f, 5f)] public float RadiusGravity { get; private set; } = 1f;
        [field: SerializeField, Min(0.1f)] public float ForceGravity { get; private set; } = 0.1f;
    }
}