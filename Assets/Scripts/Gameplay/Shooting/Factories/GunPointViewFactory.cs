using UnityEngine;
using Zenject;

namespace Gameplay.Shooting.Factories
{
    public sealed class GunPointViewFactory : PlaceholderFactory<Vector2, Quaternion, Transform, GunPointView>
    {
        private readonly GunPointView _prefab;
        private readonly DiContainer _diContainer;

        public GunPointViewFactory(GunPointView prefab, DiContainer diContainer)
        {
            _prefab = prefab;
            _diContainer = diContainer;
        }

        public override GunPointView Create(Vector2 position, Quaternion rotation, Transform parentTransform)
        {
            return _diContainer.InstantiatePrefabForComponent<GunPointView>(_prefab, position, rotation, parentTransform);
        }
    }
}