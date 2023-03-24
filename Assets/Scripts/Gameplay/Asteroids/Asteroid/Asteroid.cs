using Gameplay.Damage;
using Gameplay.Survival;
using System;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public class Asteroid : IDisposable
    {
        private readonly AsteroidMovement _asteroidMovement;
        private readonly EntitySurvival _survival;

        public AsteroidView AsteroidView { get; private set; }

        public Asteroid(AsteroidView asteroidView, AsteroidMovement asteroidMovement, EntitySurvival survival, DamageModel damageModel)
        {
            _asteroidMovement = asteroidMovement;
            _survival = survival;
            AsteroidView = asteroidView;
            AsteroidView.InitDamageModel(damageModel);

            SubscribeEvents();
        }

        public void Dispose()
        {
            _asteroidMovement.Dispose();
            _survival.Dispose();
            UnsubscribeEvents();
            Object.Destroy(AsteroidView.gameObject);
        }

        private void SubscribeEvents()
        {
            _survival.UnitDestroyed += Dispose;
        }

        private void UnsubscribeEvents()
        {
            _survival.UnitDestroyed -= Dispose;
        }
    }
}