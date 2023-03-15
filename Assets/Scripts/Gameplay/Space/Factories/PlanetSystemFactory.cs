using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using Zenject;

namespace Gameplay.Space.Factories
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
