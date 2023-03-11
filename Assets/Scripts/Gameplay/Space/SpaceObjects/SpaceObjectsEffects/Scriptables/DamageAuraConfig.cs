using UnityEngine;

namespace SpaceObjects
{
    [CreateAssetMenu(fileName = nameof(DamageAuraConfig), menuName = "Configs/Space/SpaceObjectEffects/" + nameof(DamageAuraConfig))]
    public class DamageAuraConfig : SpaceObjectEffectConfig
    {
        [field: SerializeField, Header("AuraBody")] public AreaEffectView Prefab { get; private set; }
        [field: SerializeField, Min(0.1f), Header("Radius")] public float Radius { get; private set; } = 0.1f;
        [field: SerializeField, Min(0.1f), Header("AuraDamage")] public float Damage { get; private set; } = 0.1f;
        [field: SerializeField, Min(0.1f)] public float DamageInterval { get; private set; } = 0.1f;
    }
}
