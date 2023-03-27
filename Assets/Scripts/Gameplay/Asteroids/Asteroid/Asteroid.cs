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

        private AsteroidView _view;

        public Asteroid(AsteroidView asteroidView, AsteroidMovement asteroidMovement, EntitySurvival survival)
        {
            _asteroidMovement = asteroidMovement;
            _survival = survival;
            _view = asteroidView;

            SubscribeEvents();
        }

        public void Dispose()
        {
            UnsubscribeEvents();

            _asteroidMovement.Dispose();
            _survival.Dispose();

            Object.Destroy(_view.gameObject);
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