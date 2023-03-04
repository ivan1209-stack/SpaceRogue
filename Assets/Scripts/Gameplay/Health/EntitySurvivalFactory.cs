using System;
using Scriptables.Health;
using Zenject;

namespace Gameplay.Health
{
    public class EntitySurvivalFactory : PlaceholderFactory<IHealthInfo, IShieldInfo, IDamageImmunityFrameInfo, EntitySurvival>
    {
        private readonly EntityHealthFactory _entityHealthFactory;
        private readonly EntityShieldFactory _entityShieldFactory;
        private readonly EntityDamageImmunityFrameFactory _entityDamageImmunityFrameFactory;

        public EntitySurvivalFactory(
            EntityHealthFactory entityHealthFactory,
            EntityShieldFactory entityShieldFactory,
            EntityDamageImmunityFrameFactory entityDamageImmunityFrameFactory)
        {
            _entityHealthFactory = entityHealthFactory;
            _entityShieldFactory = entityShieldFactory;
            _entityDamageImmunityFrameFactory = entityDamageImmunityFrameFactory;
        }

        public override EntitySurvival Create(IHealthInfo healthInfo, IShieldInfo shieldInfo, IDamageImmunityFrameInfo damageImmunityFrameInfo)
        {
            if (healthInfo is null) throw new ArgumentNullException(nameof(healthInfo));
            var entityHealth = _entityHealthFactory.Create(healthInfo);
            var entityShield = shieldInfo is null 
                ? null 
                : _entityShieldFactory.Create(shieldInfo);
            var entityDamageImmunityFrame = damageImmunityFrameInfo is null
                ? null
                : _entityDamageImmunityFrameFactory.Create(damageImmunityFrameInfo);

            return new EntitySurvival(entityHealth, entityShield, entityDamageImmunityFrame);
        }
    }
}