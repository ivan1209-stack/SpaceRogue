using Gameplay.Pooling;
using Gameplay.Space.SpaceObjects;
using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using UnityEngine;
using Utilities.Mathematics;
using Zenject;

namespace Gameplay.Space.Factories
{
    public class GravitationAuraFactory : PlaceholderFactory<GravitationAuraConfig, GravitationAuraEffect>
    {
        private readonly GravitationAuraViewFactory _viewFactory;
        private readonly GravitationAuraConfig _gravityConfig;

        public GravitationAuraFactory(GravitationAuraViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }

        public override GravitationAuraEffect Create(Transform transform, GravitationAuraConfig config)
        {
            var view = _viewFactory.Create(config, transform);
            return new GravitationAuraEffect(view, config);
        }
    }
}
