using System;

namespace Gameplay.Survival.Health
{
    public sealed class HealthInfo : IHealthInfo
    {
        public float MaximumHealth { get; private set; }
        public float StartingHealth { get; private set; }
        public float HealthRegen { get; private set; }

        public HealthInfo(IHealthInfo healthInfo)
        {
            MaximumHealth = healthInfo.MaximumHealth;
            StartingHealth = healthInfo.StartingHealth;
            HealthRegen = healthInfo.HealthRegen;
        }

        public HealthInfo(float maximumHealth, float startingHealth, float healthRegen, float damageImmunityFrameDuration)
        {
            MaximumHealth = maximumHealth;
            StartingHealth = startingHealth;
            HealthRegen = healthRegen;
        }

        public void SetStartingHealth(float value)
        {
            StartingHealth = Math.Clamp(value, 1, MaximumHealth);
        }
    }
}