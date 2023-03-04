using UnityEngine;

namespace Scriptables.Health
{
    [CreateAssetMenu(fileName = nameof(EntitySurvivalConfig), menuName = "Configs/Survival/" + nameof(EntitySurvivalConfig))]
    public class EntitySurvivalConfig : ScriptableObject
    {
        [field: SerializeField] public HealthConfig Health { get; private set; }
        [field: SerializeField] public ShieldConfig Shield { get; private set; }
        [field: SerializeField] public DamageImmunityFrameConfig DamageImmunityFrame { get; private set; }
    }
}