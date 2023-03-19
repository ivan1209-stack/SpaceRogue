using System;
using Gameplay.Space.SpaceObjects;
using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using UnityEngine;
using Zenject;

namespace Gameplay.Space.Factories
{
    public class SpaceObjectEffectFactory : IFactory<Transform, SpaceObjectEffectConfig, SpaceObjectEffect>
    {
        private readonly PlanetSystemEffectFactory _planetSystemEffectFactory;
        private readonly GravitationAuraFactory _gravitationAuraFactory;

        public SpaceObjectEffectFactory(
            PlanetSystemEffectFactory planetSystemEffectFactory,
            GravitationAuraFactory gravitationAuraFactory)
        {
            _planetSystemEffectFactory = planetSystemEffectFactory;
            _gravitationAuraFactory = gravitationAuraFactory;
            //TODO init other factories
        }

        public SpaceObjectEffect Create(Transform spaceObjectTransform, SpaceObjectEffectConfig config)
        {
            return config.Type switch
            {
                SpaceObjectEffectType.None => new SpaceObjectEmptyEffect(),
                SpaceObjectEffectType.PlanetSystem => _planetSystemEffectFactory.Create(spaceObjectTransform, config as PlanetSystemConfig),
                SpaceObjectEffectType.DamageAura => new DamageAuraEffect(),
                SpaceObjectEffectType.GravitationAura => _gravitationAuraFactory.Create(spaceObjectTransform, config as GravitationAuraConfig),
                SpaceObjectEffectType.DamageOnTouch => new DamageOnTouchEffect(),
                _ => throw new ArgumentOutOfRangeException(nameof(config.Type), config.Type, "A not-existent game event type is provided")
            };
        }
    }
}

