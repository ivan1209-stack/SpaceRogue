using Gameplay.Damage;
using Gameplay.Health;
using Scriptables.Health;
using Services;

public class AsteroidModel
{
    public DamageModel DamageModel { get; private set; }
    public EntityHealth EntityHealth { get; private set; }

    public AsteroidModel(AsteroidConfig config)
    {
        DamageModel = new(config.DamageConfig.DamageAmount, config.DamageConfig.UnitType);
        EntityHealth = new(new HealthInfo(config.HealthConfig), new Updater());
    }

    public void DealDamage(IDamageableView victim)
    {
        victim.TakeDamage(DamageModel);
    }

    public void DestroyAsteroid() => EntityHealth.TakeDamage(EntityHealth.MaximumHealth + 1);
}
