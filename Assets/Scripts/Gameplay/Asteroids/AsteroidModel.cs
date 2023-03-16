using Gameplay.Damage;
using Gameplay.Survival;
using Gameplay.Survival.Health;
using Services;

namespace Asteroids
{
    public class AsteroidModel
    {
        private DamageModel _damageModel;
        private EntityHealth _entityHealth;

        public AsteroidModel(AsteroidConfig config)
        {
            _damageModel = new(config.DamageConfig.DamageAmount, config.DamageConfig.UnitType);
            _entityHealth = new(new HealthInfo(config.HealthConfig), new Updater());
        }

        public void DealDamage(IDamageableView victim)
        {
            victim.TakeDamage(_damageModel);
        }

        public void DestroyAsteroid() => _entityHealth.TakeDamage(_entityHealth.MaximumHealth + 1);
    }
}