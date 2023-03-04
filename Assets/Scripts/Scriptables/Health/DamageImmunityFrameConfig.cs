using UnityEngine;

namespace Scriptables.Health
{
    [CreateAssetMenu(fileName = nameof(DamageImmunityFrameConfig), menuName = "Configs/Survival/" + nameof(DamageImmunityFrameConfig))]
    public class DamageImmunityFrameConfig : ScriptableObject, IDamageImmunityFrameInfo
    {
        [field: SerializeField, Min(0.1f)] public float SecondHitDelay { get; private set; } = 0.3f;
        [field: SerializeField, Min(0f)] public float Duration { get; private set; } = 0.5f;
        [field: SerializeField, Min(0.1f)] public float Cooldown { get; private set; } = 2.0f;
    }
}