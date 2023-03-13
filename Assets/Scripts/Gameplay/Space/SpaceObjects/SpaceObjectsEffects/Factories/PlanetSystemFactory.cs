using Zenject;
using UnityEngine;
using Scriptables.Space;

namespace SpaceObjects
{
    public class PlanetSystemFactory : PlaceholderFactory<PlanetSystemConfig, PlanetSystemEffect>
    {
        public PlanetSystemFactory()
        {

        }

        public PlanetSystemEffect CreatePlanetSystemEffect(PlanetSystemConfig config)
        {
            var planetSystemEffect = new PlanetSystemEffect();
            return planetSystemEffect;
        }
    }
}
