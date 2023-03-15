using Gameplay.Survival.DamageImmunityFrame;
using Gameplay.Survival.Health;
using Gameplay.Survival.Shield;
using UnityEngine;

namespace Gameplay.Survival
{
    [CreateAssetMenu(fileName = nameof(EntitySurvivalConfig), menuName = "Configs/Survival/" + nameof(EntitySurvivalConfig))]
    public sealed class EntitySurvivalConfig : ScriptableObject
    {
        [field: SerializeField] public HealthConfig Health { get; private set; }
        [field: SerializeField] public ShieldConfig Shield { get; private set; }
        [field: SerializeField] public DamageImmunityFrameConfig DamageImmunityFrame { get; private set; }
    }
}