using UnityEngine;
using Zenject;

namespace Asteroids
{
    public class AsteroidViewFactory : PlaceholderFactory<Vector2, AsteroidConfig, AsteroidView>
    {
        private readonly AsteroidsPool _pool;
        private readonly DiContainer _diContainer;

        public AsteroidViewFactory(AsteroidsPool pool, DiContainer container)
        {
            _pool = pool;
            _diContainer = container;
        }

        public override AsteroidView Create(Vector2 spawnPoint, AsteroidConfig config)
        {
            var newAsteroidView = _diContainer.InstantiatePrefabForComponent<AsteroidView>(config.Prefab, spawnPoint, Quaternion.identity, _pool.transform);
            newAsteroidView.InitDamageModel(config.Damage);
            return newAsteroidView;
        }
    }
}