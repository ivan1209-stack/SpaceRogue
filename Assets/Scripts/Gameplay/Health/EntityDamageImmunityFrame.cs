using System;
using Gameplay.Mechanics.Timer;
using Scriptables.Health;

namespace Gameplay.Health
{
    public class EntityDamageImmunityFrame : IDisposable
    {
        public Timer DamageImmunityFrameTimer { get; }
        public Timer DamageImmunityCooldownTimer { get; }
        
        public EntityDamageImmunityFrame(IDamageImmunityFrameInfo damageImmunityFrameInfo, TimerFactory timerFactory)
        {
            DamageImmunityFrameTimer = timerFactory.Create(damageImmunityFrameInfo.Duration);
            DamageImmunityCooldownTimer = timerFactory.Create(damageImmunityFrameInfo.Cooldown);

            DamageImmunityFrameTimer.OnExpire += StartCooldown;
        }
        
        public void Dispose()
        {
            DamageImmunityFrameTimer.OnExpire -= StartCooldown;
            
            DamageImmunityFrameTimer.Dispose();
            DamageImmunityCooldownTimer.Dispose();
        }

        internal void StartImmunityFrame()
        {
            DamageImmunityFrameTimer.Start();
        }

        private void StartCooldown()
        {
            DamageImmunityCooldownTimer.Start();
        }
    }
}