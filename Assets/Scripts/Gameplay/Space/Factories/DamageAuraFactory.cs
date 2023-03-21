using Gameplay.Pooling;
using Gameplay.Space.SpaceObjects;
using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects;
using UnityEngine;
using Utilities.Mathematics;
using Zenject;

namespace Gameplay.Space.Factories
{
    public class DamageAuraFactory : PlaceholderFactory<Transform, DamageAuraConfig, DamageAuraEffect>
    {
        private readonly DamageAuraViewFactory _viewFactory;

        public DamageAuraFactory(DamageAuraViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }

        public override DamageAuraEffect Create(Transform transform, DamageAuraConfig config)
        {
            var view = _viewFactory.Create(transform, config);
            return new DamageAuraEffect(view, config);
        }
    }
}