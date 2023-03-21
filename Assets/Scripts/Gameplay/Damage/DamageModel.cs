using Abstracts;

namespace Gameplay.Damage
{
    public sealed class DamageModel
    {
        public float MinDamage { get; }
        public float MaxDamage { get; }
        public UnitType UnitType { get; }

        public DamageModel(float minDamage, float maxDamage)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            UnitType = UnitType.None;
        }
        
        public DamageModel(float damageAmount)
        {
            MinDamage = damageAmount;
            MaxDamage = damageAmount;
            UnitType = UnitType.None;
        }

        public DamageModel(float minDamage, float maxDamage, UnitType unitType)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            UnitType = unitType;
        }
        
        public DamageModel(float damageAmount, UnitType unitType)
        {
            MinDamage = damageAmount;
            MaxDamage = damageAmount;
            UnitType = unitType;
        }
    }
}