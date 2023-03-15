using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using Zenject;

namespace Gameplay.Space.Factories
{
    public class GravitationAuraFactory : PlaceholderFactory<GravitationAuraConfig, GravitationAuraEffect>
    {
        public GravitationAuraFactory()
        {

        }

        public GravitationAuraEffect CreateGravitationAuraEffect(GravitationAuraConfig config)
        {
            return base.Create(config);
        }

    }
}