using Abstracts;
using Gameplay.Mechanics.Timer;
using Gameplay.Shooting.Factories;
using Gameplay.Shooting.Scriptables;
using UnityEngine;

namespace Gameplay.Shooting
{
    public class Railgun : Weapon
    {
        private readonly RailgunConfig _railgunConfig;
        private readonly UnitType _unitType;
        private readonly ProjectileFactory _projectileFactory;

        public Railgun(RailgunConfig railgunConfig, UnitType unitType, ProjectileFactory projectileFactory, TimerFactory timerFactory)
        {
            _railgunConfig = railgunConfig;
            _unitType = unitType;
            _projectileFactory = projectileFactory;
            CooldownTimer = timerFactory.Create(railgunConfig.Cooldown);
        }

        public override void CommenceFiring(Vector2 bulletPosition, Quaternion turretDirection)
        {
            if (IsOnCooldown) return;

            _projectileFactory.Create(new ProjectileSpawnParams(bulletPosition, turretDirection, _unitType, _railgunConfig.RailgunProjectile));
            
            CooldownTimer.Start();
        }
    }
}