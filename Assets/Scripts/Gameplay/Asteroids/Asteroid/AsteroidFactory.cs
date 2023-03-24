using Gameplay.Damage;
using Gameplay.Survival;
using UnityEngine;
using Zenject;

namespace Asteroids
{
    public class AsteroidFactory : PlaceholderFactory<Vector2, Vector2, AsteroidConfig, Asteroid>
    {
        private readonly AsteroidViewFactory _asteroidViewFactory;
        private readonly AsteroidMovementFactory _asteroidMovementFactory;
        private readonly EntitySurvivalFactory _entitySurvivalFactory;

        public AsteroidFactory(AsteroidViewFactory asteroidViewFactory, AsteroidMovementFactory asteroidMovementFactory, EntitySurvivalFactory entitySurvivalFactory)
        {
            _asteroidViewFactory = asteroidViewFactory;
            _asteroidMovementFactory = asteroidMovementFactory;
            _entitySurvivalFactory = entitySurvivalFactory;
        }

        public override Asteroid Create(Vector2 spawnPoint, Vector2 basePoint, AsteroidConfig config)
        {
            var view = _asteroidViewFactory.Create(spawnPoint, config);
            var movement = _asteroidMovementFactory.Create(config.AsteroidMoveConfig, view, basePoint);
            var survival = _entitySurvivalFactory.Create(config.SurvivalConfig);
            var damage = new DamageModel(config.DamageConfig.DamageAmount);
            return new(view, movement, survival, damage);
        }
    }
}