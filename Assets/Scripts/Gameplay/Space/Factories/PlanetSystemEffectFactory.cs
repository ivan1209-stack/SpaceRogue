using System.Collections.Generic;
using Gameplay.Space.Planets;
using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using UnityEngine;
using Utilities.Mathematics;
using Zenject;

namespace Gameplay.Space.Factories
{
    public class PlanetSystemEffectFactory : PlaceholderFactory<Vector3, PlanetSystemConfig, PlanetSystemEffect>
    {
        private readonly PlanetFactory _planetFactory;

        public PlanetSystemEffectFactory(PlanetFactory planetFactory)
        {
            _planetFactory = planetFactory;
        }

        public override PlanetSystemEffect Create(Vector3 spaceObjectScale, PlanetSystemConfig config)
        {
            List<Planet> planets = new();
            int planetCount = RandomPicker.PickRandomBetweenTwoValues(config.MinPlanetCount, config.MaxPlanetCount);
            return base.Create(spaceObjectScale, config);
        }
    }
}