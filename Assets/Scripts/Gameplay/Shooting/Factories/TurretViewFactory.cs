using UnityEngine;
using Zenject;

namespace Gameplay.Shooting.Factories
{
    public sealed class TurretViewFactory : PlaceholderFactory<Transform, TurretView>
    {
        private readonly TurretView _prefab;
        private readonly DiContainer _diContainer;

        public TurretViewFactory(TurretView prefab, DiContainer diContainer)
        {
            _prefab = prefab;
            _diContainer = diContainer;
        }
        
        public override TurretView Create(Transform parentTransform)
        {
            return _diContainer.InstantiatePrefabForComponent<TurretView>(_prefab, parentTransform);
        }
    }
}