using UnityEngine;

namespace Scriptables.Health
{
    [CreateAssetMenu(fileName = nameof(EntitySurvivalConfig), menuName = "Configs/Survival/" + nameof(EntitySurvivalConfig))]
    public class EntitySurvivalConfig : ScriptableObject
    {
        [field: SerializeField] public IHealthInfo Health { get; private set; }
        [field: SerializeField] public IShieldInfo Shield { get; private set; }
        [field: SerializeField] public IDamageImmunityFrameInfo DamageImmunityFrame { get; private set; }
    }
}