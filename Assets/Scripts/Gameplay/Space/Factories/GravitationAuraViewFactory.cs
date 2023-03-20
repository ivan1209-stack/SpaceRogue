using Gameplay.Pooling;
using Gameplay.Space.SpaceObjects;
using Gameplay.Space.SpaceObjects.Scriptables;
using UnityEngine;
using Utilities.Mathematics;
using Zenject;

namespace Gameplay.Space.Factories
{
    public class GravitationAuraViewFactory : PlaceholderFactory<Transform, GravitationAuraConfig,  GravitationAuraEffectView>
    {
        private readonly DiContainer _diContainer;

        public GravitationAuraViewFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public override GravitationAuraEffectView Create(Transform transform, GravitationAuraConfig config)
        {
            var size = transform.localScale.x + config.Radius;
            var effectTransform = transform;
            effectTransform.localScale = new Vector3(size, size, 1);
            var view = _diContainer.InstantiatePrefabForComponent<GravitationAuraEffectView>(config.Prefab, effectTransform);
            return view;
        }
    }
}