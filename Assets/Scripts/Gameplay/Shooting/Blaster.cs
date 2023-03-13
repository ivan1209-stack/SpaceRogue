using Abstracts;
using Gameplay.Mechanics.Timer;
using Gameplay.Shooting.Factories;
using Gameplay.Shooting.Scriptables;
using UnityEngine;

namespace Gameplay.Shooting
{
    public class Blaster : Weapon
    {
        private readonly BlasterConfig _blasterConfig;
        private readonly UnitType _unitType;
        private readonly ProjectileFactory _projectileFactory;

        public Blaster(BlasterConfig blasterConfig, UnitType unitType, ProjectileFactory projectileFactory, TimerFactory timerFactory)
        {
            _blasterConfig = blasterConfig;
            _unitType = unitType;
            _projectileFactory = projectileFactory;
            CooldownTimer = timerFactory.Create(blasterConfig.Cooldown);
        }
        
        public override void CommenceFiring(Vector2 bulletPosition, Quaternion turretDirection)
        {
            if (IsOnCooldown) return;

            _projectileFactory.Create(new ProjectileSpawnParams(bulletPosition, turretDirection, _unitType, _blasterConfig.BlasterProjectile));
            
            CooldownTimer.Start();
        }
    }
}