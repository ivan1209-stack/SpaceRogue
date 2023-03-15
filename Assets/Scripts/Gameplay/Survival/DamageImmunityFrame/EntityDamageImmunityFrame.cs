using System;
using Gameplay.Mechanics.Timer;

namespace Gameplay.Survival.DamageImmunityFrame
{
    public sealed class EntityDamageImmunityFrame : IDisposable
    {
        public Timer DamageImmunityFrameTimer { get; }
        public Timer DamageImmunityCooldownTimer { get; }
        
        private readonly Timer _secondHitTimer;
        
        public EntityDamageImmunityFrame(IDamageImmunityFrameInfo damageImmunityFrameInfo, TimerFactory timerFactory)
        {
            DamageImmunityFrameTimer = timerFactory.Create(damageImmunityFrameInfo.Duration);
            DamageImmunityCooldownTimer = timerFactory.Create(damageImmunityFrameInfo.Cooldown);
            _secondHitTimer = timerFactory.Create(damageImmunityFrameInfo.SecondHitDelay);

            DamageImmunityFrameTimer.OnExpire += StartCooldown;
        }
        
        public void Dispose()
        {
            DamageImmunityFrameTimer.OnExpire -= StartCooldown;
            
            _secondHitTimer.Dispose();
            DamageImmunityFrameTimer.Dispose();
            DamageImmunityCooldownTimer.Dispose();
        }

        internal bool TryBlockDamage()
        {
            if (DamageImmunityCooldownTimer.InProgress) return false;
            if (DamageImmunityFrameTimer.InProgress) return true;

            if (_secondHitTimer.InProgress)
            {
                _secondHitTimer.SetToZero();
                StartImmunityFrame();
                return true;
            }
            
            _secondHitTimer.Start();
            return false;
        }

        private void StartImmunityFrame()
        {
            DamageImmunityFrameTimer.Start();
        }

        private void StartCooldown()
        {
            DamageImmunityCooldownTimer.Start();
        }
    }
}