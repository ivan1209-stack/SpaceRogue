using Abstracts;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects.Views;
using UnityEngine;

namespace Gameplay.Space.SpaceObjects.Scriptables
{
    [CreateAssetMenu(fileName = nameof(GravitationAuraConfig), menuName = "Configs/Space/SpaceObjectEffects/" + nameof(GravitationAuraConfig))]
    public class GravitationAuraConfig : SpaceObjectEffectConfig
    {
        [field: SerializeField] public GravitationAuraEffectView Prefab { get; private set; }
        [field: SerializeField, Range(1f,5f)] public float Radius { get; private set; } = 1f;
        [field: SerializeField, Min(0.1f)] public float GravityForce { get; private set; } = 0.1f;
        [field: SerializeField, Min(0.1f)] public float GravityVariation { get; private set; } = 0.1f;
        [field: SerializeField, Min(0.1f)] public float GravityDistanceScale { get; private set; } = 0.1f;
        [field: SerializeField] public EffectorForceMode2D GravityMode { get; private set; } = EffectorForceMode2D.Constant;

        public GravitationAuraConfig() => Type = SpaceObjectEffectType.GravitationAura;
    }
}