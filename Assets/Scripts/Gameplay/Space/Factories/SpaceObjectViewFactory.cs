using Gameplay.Pooling;
using Gameplay.Space.SpaceObjects;
using Gameplay.Space.SpaceObjects.Scriptables;
using UnityEngine;
using Utilities.Mathematics;
using Zenject;

namespace Gameplay.Space.Factories
{
    public class SpaceObjectViewFactory : PlaceholderFactory<Vector2, SpaceObjectConfig, SpaceObjectView>
    {
        private readonly SpaceObjectsPool _spaceObjectsPool;
        private readonly DiContainer _diContainer;
        private readonly System.Random _random;

        public SpaceObjectViewFactory(SpaceObjectsPool spaceObjectsPool, DiContainer diContainer)
        {
            _spaceObjectsPool = spaceObjectsPool;
            _diContainer = diContainer;
            _random = new System.Random();
        }
        
        public override SpaceObjectView Create(Vector2 position, SpaceObjectConfig config)
        {
            var view = _diContainer.InstantiatePrefabForComponent<SpaceObjectView>(config.Prefab, position, Quaternion.identity, _spaceObjectsPool.transform);
            var size = RandomPicker.PickRandomBetweenTwoValues(config.MinSize, config.MaxSize, _random);
            view.transform.localScale = new Vector3(size, size, 1);
            return view;
        }
    }
}