using System;
using Scriptables.Health;

namespace Gameplay.Health
{
    public class UnitHealth
    {
        private readonly float _healthRegenAmount;
        private readonly float _damageImmunityFrameDuration;
        
        public event Action UnitDestroyed = () => { };
        public event Action DamageTaken = () => { };

        public float CurrentHealth { get; private set; }
        public float MaximumHealth { get; }
        
        
        public UnitHealth(IHealthInfo healthInfo)
        {
            MaximumHealth = healthInfo.MaximumHealth;
            CurrentHealth = healthInfo.StartingHealth;
            _healthRegenAmount = healthInfo.HealthRegen;
            _damageImmunityFrameDuration = healthInfo.DamageImmunityFrameDuration;
        }
        
        //TODO continue model transfer
    }
}