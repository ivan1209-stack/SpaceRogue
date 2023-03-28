using Gameplay.Survival;
using System;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public class Asteroid : IDisposable
    {
        private readonly IMovementBehaviour _asteroidMovement;
        private readonly EntitySurvival _survival;
        private readonly AsteroidView _view;


        public Asteroid(AsteroidView view, IMovementBehaviour asteroidMovement, EntitySurvival survival)
        {
            _asteroidMovement = asteroidMovement;
            _survival = survival;
            _view = view;

            _survival.UnitDestroyed += Dispose;
        }

        public void Dispose()
        {
            _survival.UnitDestroyed -= Dispose;
            _survival.Dispose();

            _asteroidMovement.Dispose();

            Object.Destroy(_view.gameObject);
        }
    }
}