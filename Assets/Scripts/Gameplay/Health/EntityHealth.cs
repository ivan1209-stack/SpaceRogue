using System;
using Scriptables.Health;
using Services;

namespace Gameplay.Health
{
    public class EntityHealth : IDisposable
    {
        private readonly Updater _updater;
        private readonly float _healthRegenAmount;
        
        public event Action HealthReachedZero = () => { };

        public float CurrentHealth { get; private set; }
        public float MaximumHealth { get; }
        
        
        public EntityHealth(IHealthInfo healthInfo, Updater updater)
        {
            _updater = updater;
            MaximumHealth = healthInfo.MaximumHealth;
            CurrentHealth = healthInfo.StartingHealth;
            _healthRegenAmount = healthInfo.HealthRegen;
            _updater.SubscribeToUpdate(RegenerateHealth);
        }

        public void Dispose()
        {
            _updater.UnsubscribeFromUpdate(RegenerateHealth);
        }

        internal void TakeDamage(float damageAmount)
        {
            if (damageAmount < 0) throw new ArgumentException("Damage cannot be less than zero!");
            if (damageAmount >= CurrentHealth)
            {
                CurrentHealth = 0.0f;
                HealthReachedZero.Invoke();
                return;
            }

            CurrentHealth -= damageAmount;
        }

        internal void Heal(float healingAmount)
        {
            if (healingAmount < 0) throw new ArgumentException("Healing cannot be less than zero!");
            CurrentHealth += healingAmount;
            if (CurrentHealth > MaximumHealth) CurrentHealth = MaximumHealth;
        }

        private void RegenerateHealth(float deltaTime)
        {
            if (CurrentHealth < MaximumHealth)
            {
                Heal(_healthRegenAmount * deltaTime);
            }
        }
    }
}