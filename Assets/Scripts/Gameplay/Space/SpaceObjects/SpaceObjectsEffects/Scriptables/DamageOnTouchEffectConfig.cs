using UnityEngine;

namespace Scriptables.Space
{
    [CreateAssetMenu(fileName = nameof(DamageOnTouchEffectConfig), menuName = "Configs/Space/SpaceObjectEffects/" + nameof(DamageOnTouchEffectConfig))]
    public class DamageOnTouchEffectConfig : SpaceObjectEffectConfig
    {
        [field: SerializeField, Min(0.1f)] public float Damage { get; private set; }
    }
}