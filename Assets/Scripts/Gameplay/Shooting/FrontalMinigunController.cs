using Abstracts;
using Gameplay.Mechanics.Meter;
using Gameplay.Mechanics.Timer;
using Scriptables.Modules;
using UnityEngine;
using Utilities.Mathematics;
using Random = System.Random;

namespace Gameplay.Shooting
{
    public sealed class FrontalMinigunController : FrontalTurretController
    {
        private readonly MinigunConfig _config;
        
        private readonly MeterWithCooldown _overheatMeter;
        
        private float _currentSprayAngle;

        public FrontalMinigunController(TurretModuleConfig config, Transform gunPointParentTransform, UnitType unitType) : base(config, gunPointParentTransform, unitType)
        {
            var minigunConfig = config.SpecificWeapon as MinigunConfig;
            _config = minigunConfig ? minigunConfig : throw new System.Exception("wrong config type was provided");

            _overheatMeter = new MeterWithCooldown(0.0f, _config.TimeToOverheat, _config.OverheatCoolDown, new TimerFactory());
            _overheatMeter.OnCooldownEnd += ResetSpray;
            _currentSprayAngle = _config.SprayAngle;
        }

        protected override void OnDispose()
        {
            _overheatMeter.OnCooldownEnd -= ResetSpray;
            _overheatMeter.Dispose();
            base.OnDispose();
        }

        public override void CommenceFiring()
        {
            if (_overheatMeter.IsOnCooldown || IsOnCooldown) return;

            FireSingleProjectile();
            AddHeat();
            CooldownTimer.Start();
        }

        private void AddHeat()
        {
            _overheatMeter.Fill(_config.Cooldown);
            IncreaseSpray();
        }

        private void IncreaseSpray()
        {
            if (_currentSprayAngle >= _config.MaxSprayAngle) return;
            var sprayIncrease = CountSprayIncrease();
            _currentSprayAngle += sprayIncrease;
        }

        private float CountSprayIncrease()
        {
            return (_config.MaxSprayAngle - _config.SprayAngle) / (_config.TimeToOverheat * (1 / _config.Cooldown));
        }

        private void ResetSpray()
        {
            _currentSprayAngle = _config.SprayAngle;
        }

        private void FireSingleProjectile()
        {
            float angle = _currentSprayAngle / 2;
            Random r = new Random();

            float pelletAngle = RandomPicker.PickRandomBetweenTwoValues(-angle, angle, r);
            Vector3 pelletVector = (pelletAngle + 90).ToVector3();
            //TODO check 90 degrees turn
            var projectile = ProjectileFactory.CreateProjectile(pelletVector);
            AddController(projectile);
        }
    }   
}