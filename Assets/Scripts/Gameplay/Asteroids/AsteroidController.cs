using Abstracts;
using System;

namespace Asteroids
{
    public class AsteroidController : BaseController
    {
        private AsteroidView _view;
        private AsteroidModel _model;
        private AsteroidMovementControllerBase _moveController;

        public AsteroidController(AsteroidView view, AsteroidConfig config)
        {
            _view = view;
            _model = new(config);

            CreateMoveController(config.AsteroidMoveConfig);
            SubscribeViewEvents();
            AddController(this);
        }

        protected override void OnDispose()
        {
            _model = null;
            _moveController.Dispose();
            UnsubscribeViewEvents();
        }

        private void SubscribeViewEvents()
        {
            _view.DamageDealt += _model.DealDamage;
            _view.ObjectDestroyed += _model.DestroyAsteroid;
            _view.ObjectDestroyed += OnDispose;
        }

        private void UnsubscribeViewEvents()
        {
            _view.DamageDealt -= _model.DealDamage;
            _view.ObjectDestroyed -= _model.DestroyAsteroid;
            _view.ObjectDestroyed -= OnDispose;
        }

        private AsteroidMovementControllerBase CreateMoveController(AsteroidMoveConfig config)
        {
            switch (config.MoveType)
            {
                case AsteroidMoveType.None:
                    throw new Exception("Asteroid move type not set");
                case AsteroidMoveType.RandomDirected:
                    return new AsteroidRandomDirectedMovementController(_view, config);
                default:
                    throw new Exception("Invalid asteroid move type set"); ;
            }
        }
    }
}