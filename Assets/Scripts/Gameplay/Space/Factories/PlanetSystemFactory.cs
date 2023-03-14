using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using Zenject;
using UnityEngine;

namespace SpaceObjects
{
    public class PlanetSystemFactory : PlaceholderFactory<PlanetSystemConfig, PlanetSystemEffect>
    {
        public PlanetSystemFactory()
        {

        }

        public PlanetSystemEffect CreatePlanetSystemEffect(PlanetSystemConfig config)
        {
            return base.Create(config);
        }
    }
}
