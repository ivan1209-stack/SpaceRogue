using Gameplay.Space.Generator;
using Zenject;

namespace Gameplay.Space.Factories
{
    public sealed class SpaceViewFactory : PlaceholderFactory<SpaceView>
    {
        private readonly DiContainer _diContainer;
        private readonly SpaceView _spaceViewPrefab;

        public SpaceViewFactory(DiContainer diContainer, SpaceView spaceViewPrefab)
        {
            _diContainer = diContainer;
            _spaceViewPrefab = spaceViewPrefab;
        }

        public override SpaceView Create()
        {
            return _diContainer.InstantiatePrefabForComponent<SpaceView>(_spaceViewPrefab);
        }
    }
}