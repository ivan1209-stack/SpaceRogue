using Gameplay.Pooling;
using Gameplay.Space.SpaceObjects;
using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects.Views;
using UnityEngine;
using Utilities.Mathematics;
using Zenject;

namespace Gameplay.Space.Factories
{
    public class DamageOnTouchViewFactory : PlaceholderFactory<Transform, DamageOnTouchConfig, DamageOnTouchEffectView>
    {
        private readonly DiContainer _diContainer;

        public DamageOnTouchViewFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public override DamageOnTouchEffectView Create(Transform transform, DamageOnTouchConfig config)
        {
            var view = _diContainer.InstantiatePrefabForComponent<DamageOnTouchEffectView>(config.Prefab, transform);
            var size = transform.localScale.x;
            view.transform.localScale = new Vector3(size, size, 1);
            return view;
        }
    }
}