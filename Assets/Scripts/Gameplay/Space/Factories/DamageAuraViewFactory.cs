using Gameplay.Pooling;
using Gameplay.Space.SpaceObjects;
using Gameplay.Space.SpaceObjects.Scriptables;
using Gameplay.Space.SpaceObjects.SpaceObjectsEffects.Views;
using UnityEngine;
using Utilities.Mathematics;
using Zenject;

namespace Gameplay.Space.Factories
{
    public class DamageAuraViewFactory : PlaceholderFactory<Transform, DamageAuraConfig, DamageAuraView>
    {
        private readonly DiContainer _diContainer;

        public DamageAuraViewFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public override DamageAuraView Create(Transform transform, DamageAuraConfig config)
        {
            var view = _diContainer.InstantiatePrefabForComponent<DamageAuraView>(config.Prefab, transform);
            var size = transform.localScale.x;
            view.transform.localScale = new Vector3(size, size, 1);
            return view;
        }
    }
}