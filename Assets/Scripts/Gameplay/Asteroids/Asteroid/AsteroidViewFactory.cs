using UnityEngine;
using Zenject;

namespace Asteroids
{
    public class AsteroidViewFactory : PlaceholderFactory<Vector2, AsteroidConfig, AsteroidView>
    {
        private readonly AsteroidsPool _pool;
        private readonly DiContainer _diContainer;

        public AsteroidViewFactory(AsteroidsPool pool, DiContainer diContainer)
        {
            _pool = pool;
            _diContainer = diContainer;
        }

        public override AsteroidView Create(Vector2 spawnPoint, AsteroidConfig config)
        {
            var newAsteroidView = _diContainer.InstantiatePrefabForComponent<AsteroidView>(config.Prefab, spawnPoint, Quaternion.identity, _pool.transform);
            newAsteroidView.Init(config.Damage);
            return newAsteroidView;
        }
    }
}