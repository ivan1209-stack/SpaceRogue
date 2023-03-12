using System;
using Gameplay.Mechanics.Timer;
using UnityEngine;

namespace Gameplay.Shooting
{
    public abstract class Weapon : IDisposable
    {
        protected Timer CooldownTimer { get; set; }
        protected bool IsOnCooldown => CooldownTimer.InProgress;

        public void Dispose()
        {
            CooldownTimer.Dispose();
        }

        public abstract void CommenceFiring(Vector2 bulletPosition, Quaternion turretDirection);
    }
}