using UnityEngine;

namespace SpaceObjects
{
    [CreateAssetMenu(fileName = nameof(DamageAuraConfig), menuName = "Configs/Space/" + nameof(DamageAuraConfig))]
    public class DamageAuraConfig : SpaceObjectEffectConfig
    {
        [field: SerializeField, Header("AuraBody")] public DamageAuraView Prefab { get; private set; }
        [field: SerializeField, Range(1f, 5f), Header("AuraRadius")] public float DamageRadius { get; private set; } = 1;
        [field: SerializeField, Min(0), Header("AuraDamage")] public int DamageValue { get; private set; } = 0;
        [field: SerializeField, Min(0.1f)] public float DamageCooldown { get; private set; } = 0.1f;
    }
}
