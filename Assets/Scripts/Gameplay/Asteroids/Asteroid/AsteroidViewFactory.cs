using UnityEngine;
using Zenject;

namespace Asteroids
{
    public class AsteroidViewFactory : PlaceholderFactory<Vector2, AsteroidConfig, AsteroidView>
    {
        private readonly AsteroidsPool _pool;
        private readonly DiContainer _container;

        public AsteroidViewFactory(AsteroidsPool pool, DiContainer container)
        {
            _pool = pool;
            _container = container;
        }

        public override AsteroidView Create(Vector2 spawnPoint, AsteroidConfig config)
        {
            return _container.InstantiatePrefabForComponent<AsteroidView>(config.AsteroidPrefab, spawnPoint, Quaternion.identity, _pool.transform);
        }
    }
}