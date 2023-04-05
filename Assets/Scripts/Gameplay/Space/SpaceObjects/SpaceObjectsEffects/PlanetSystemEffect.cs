using System.Collections.Generic;
using System.Linq;
using Gameplay.Space.Planets;
using UnityEngine;
using Services;

namespace Gameplay.Space.SpaceObjects.SpaceObjectsEffects
{
    public sealed class PlanetSystemEffect : SpaceObjectEffect
    {
        private readonly List<Planet> _planets;
        private readonly Transform _spaceObjectTransform;
        private readonly Updater _updater;

        public PlanetSystemEffect(List<Planet> planets, Transform spaceObjectTransform, Updater updater)
        {
            _updater = updater;
            _planets = planets;
            _spaceObjectTransform = spaceObjectTransform;

            foreach (var planet in planets)
            {
                planet.PlanetDestroyed += RemovePlanet;
            }
        }

        public override void Dispose()
        {
            if (!_planets.Any()) return;

            foreach (var planet in _planets)
            {
                planet.PlanetDestroyed -= RemovePlanet;
                planet.Dispose();
            }
            _planets.Clear();
        }

        private void RemovePlanet(Planet planet)
        {
            planet.PlanetDestroyed -= RemovePlanet;
            _planets.Remove(planet); 
            //TODO if spaceObject is destroyed all planets should be transferred to Level or Space instead of removing
        }
    }
}
