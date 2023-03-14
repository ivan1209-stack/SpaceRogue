using Zenject;
using Scriptables.Space;
using UnityEngine;
using System;
using Gameplay.Space.SpaceObjects;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;

namespace SpaceObjects
{
    public class SpaceObjectEffectsFactory : PlaceholderFactory<ApplicableSpaceObjectEffect, SpaceObjectEffect>
    {
        public SpaceObjectEffectsFactory()
        {

        }

        public SpaceObjectEffect CreateSpaceObjectEffect(ApplicableSpaceObjectEffect config)
        {
            return config.Type switch
            {
                SpaceObjectEffectType.None => new SpaceObjectEmptyEffect(),
                SpaceObjectEffectType.PlanetSystem => new PlanetSystemEffect(),
                SpaceObjectEffectType.DamageAura => new DamageAuraEffect(),
                SpaceObjectEffectType.GravitationAura => new GravitationAuraEffect(),
                SpaceObjectEffectType.DamageOnTouch => new DamageOnTouchEffect(),
                _ => throw new ArgumentOutOfRangeException(nameof(config.Type), config.Type, "A not-existent game event type is provided")
            };
        }
    }
}

