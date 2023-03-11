using UnityEngine;

namespace SpaceObjects
{
    [CreateAssetMenu(fileName = nameof(DamageAuraConfig), menuName = "Configs/Space/SpaceObjectEffects/" + nameof(DamageAuraConfig))]
    public class DamageAuraConfig : SpaceObjectEffectConfig
    {
        [field: SerializeField, Header("AuraBody")] public AreaEffectView Prefab { get; private set; }
        [field: SerializeField, Min(1f), Header("Radius")] public float Radius { get; private set; } = 1;
        [field: SerializeField, Min(0), Header("AuraDamage")] public int Damage { get; private set; } = 0;
        [field: SerializeField, Min(0.1f)] public float DamageCooldown { get; private set; } = 0.1f;
    }
}
