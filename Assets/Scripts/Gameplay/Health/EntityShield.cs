using System;
using Gameplay.Mechanics.Timer;
using Scriptables.Health;

namespace Gameplay.Health
{
    public class EntityShield : IDisposable
    {
        public float CurrentShield { get; private set; }
        public float MaximumShield { get; }

        public Timer ShieldCooldownTimer { get; }

        public EntityShield(IShieldInfo shieldInfo, TimerFactory timerFactory)
        {
            CurrentShield = shieldInfo.StartingShield;
            MaximumShield = shieldInfo.MaximumShield;
            
            ShieldCooldownTimer = timerFactory.Create(shieldInfo.Cooldown);
            ShieldCooldownTimer.OnExpire += RefreshShield;
            ShieldCooldownTimer.Start();
        }

        public void Dispose()
        {
            ShieldCooldownTimer.OnExpire -= RefreshShield;
            ShieldCooldownTimer.Dispose();
        }

        internal void TakeDamage(float damageAmount)
        {
            CurrentShield = damageAmount > CurrentShield 
                ? CurrentShield = 0.0f 
                : CurrentShield - damageAmount;
            
            StartShieldCooldown();
        }
        
        private void StartShieldCooldown()
        {
            ShieldCooldownTimer.Start();
        }

        private void RefreshShield()
        {
            CurrentShield = MaximumShield;
        }
    }
}