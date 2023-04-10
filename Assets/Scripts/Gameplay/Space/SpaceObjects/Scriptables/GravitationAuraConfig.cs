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
        [field: SerializeField, Range(1f, 5f)] public float Radius { get; private set; } = 1f;
        [field: SerializeField, Min(0.1f), Tooltip("Force of gravitation.")] public float GravityForce { get; private set; } = 0.1f;
        [field: SerializeField, Min(0.1f), Tooltip("The variation of the gravitation of the force to be applied.")] public float GravityVariation { get; private set; } = 0.1f;
        [field: SerializeField, Min(0.1f), Tooltip("The scale applied to the distance between the source and target.When calculating the distance, it is scaled by this amount allowing the effective distance to be changed which controls the gravitation of the force applied.")] public float GravityDistanceScale { get; private set; } = 0.1f;
        [field: SerializeField, Tooltip("Constant - the same attraction in the entire zone. Linear and square - change in attraction from the edge to the center.")] public EffectorForceMode2D GravityMode { get; private set; } = EffectorForceMode2D.Constant;
        public GravitationAuraConfig() => Type = SpaceObjectEffectType.GravitationAura;
    }
}