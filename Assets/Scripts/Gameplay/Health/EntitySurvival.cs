using System;

namespace Gameplay.Health
{
    public class EntitySurvival : IDisposable
    {
        private readonly EntityHealth _entityHealth;
        private readonly EntityShield _entityShield;
        private readonly EntityDamageImmunityFrame _entityDamageImmunityFrame;

        public event Action UnitDestroyed = () => { };

        public EntitySurvival(EntityHealth entityHealth, EntityShield entityShield, EntityDamageImmunityFrame entityDamageImmunityFrame)
        {
            _entityHealth = entityHealth;
            _entityShield = entityShield;
            _entityDamageImmunityFrame = entityDamageImmunityFrame;

            _entityHealth.HealthReachedZero += OnHealthReachedZero;
        }

        public void Dispose()
        {
            _entityHealth.HealthReachedZero -= OnHealthReachedZero;
            
            _entityHealth.Dispose();
            _entityShield.Dispose();
            _entityDamageImmunityFrame.Dispose();
        }

        internal void TakeDamage(float damageAmount)
        {
            if (_entityDamageImmunityFrame is not null && _entityDamageImmunityFrame.TryBlockDamage()) return;
            if (_entityShield is null || _entityShield.CurrentShield == 0.0f)
            {
                TakeFullDamageToHealth(damageAmount);
            }
            else
            {
                TakeDamageToShieldThenHealth(damageAmount);
            }
        }

        internal void RestoreHealth(float healthAmount)
        {
            _entityHealth.Heal(healthAmount);
        }

        private void TakeFullDamageToHealth(float damageAmount)
        {
            _entityHealth.TakeDamage(damageAmount);
        }
        
        private void TakeDamageToShieldThenHealth(float damageAmount)
        {
            _entityShield.TakeDamage(damageAmount, out float remainingDamage);
            if (remainingDamage > 0.0f) _entityHealth.TakeDamage(remainingDamage);
        }

        private void OnHealthReachedZero()
        {
            UnitDestroyed.Invoke();
        }
    }
}