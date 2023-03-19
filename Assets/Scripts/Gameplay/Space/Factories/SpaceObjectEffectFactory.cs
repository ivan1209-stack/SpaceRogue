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

        public SpaceObjectEffectFactory(
            PlanetSystemEffectFactory planetSystemEffectFactory)
        {
            _planetSystemEffectFactory = planetSystemEffectFactory;
            //TODO init other factories
        }

        public SpaceObjectEffect Create(Transform spaceObjectTransform, SpaceObjectEffectConfig config)
        {
            return config.Type switch
            {
                SpaceObjectEffectType.None => new SpaceObjectEmptyEffect(),
                SpaceObjectEffectType.PlanetSystem => _planetSystemEffectFactory.Create(spaceObjectTransform, config as PlanetSystemConfig),
                SpaceObjectEffectType.DamageAura => new DamageAuraEffect(),
                SpaceObjectEffectType.GravitationAura => new GravitationAuraEffect(),
                SpaceObjectEffectType.DamageOnTouch => new DamageOnTouchEffect(),
                _ => throw new ArgumentOutOfRangeException(nameof(config.Type), config.Type, "A not-existent game event type is provided")
            };
        }
    }
}

