using Abstracts;
using Gameplay.Enemy.Behaviour;
using Gameplay.Movement;
using Gameplay.Player;
using Gameplay.Shooting;
using Scriptables.Health;
using Gameplay.Enemy.Scriptables;
using UI;
using UI.Game;
using UnityEngine;
using Utilities.ResourceManagement;

namespace Gameplay.Enemy
{
    public sealed class EnemyController : BaseController
    {
        public EnemyView View => _view;

        private readonly EnemyView _view;
        private readonly LegacyEnemyConfig _config;
        private readonly Weapon _turret;
        private readonly EnemyBehaviourController _behaviourController;
        private readonly PlayerController _playerController;
        private readonly System.Random _random = new();

        private readonly ResourcePath _enemyHealthStatusBarCanvasPath = 
            new(Constants.Prefabs.Canvas.Game.EnemyHealthStatusBarCanvas);
        private readonly ResourcePath _enemyHealthShieldStatusBarCanvasPath = 
            new(Constants.Prefabs.Canvas.Game.EnemyHealthShieldStatusBarCanvas);

        public EnemyController(LegacyEnemyConfig config, EnemyView view, PlayerController playerController, Transform target)
        {
            _playerController = playerController;
            _config = config;
            _view = view;
            AddGameObject(_view.gameObject);
            //_turret = WeaponFactory.CreateFrontalTurret(PickTurret(_config.TurretConfigs, _random), _view.transform, UnitType.Enemy);
            //AddController(_turret);
            
            var movementModel = new UnitMovementModel(_config.UnitMovement);
            _behaviourController = new(movementModel, _view, _turret, _playerController, _config.Behaviour, target);
            AddController(_behaviourController);

            AddEnemyHealthUIController(_config.Health, _config.Shield);
        }

        private EnemyHealthUIController AddEnemyHealthUIController(HealthConfig healthConfig, ShieldConfig shieldConfig)
        {
            /*var healthController = shieldConfig is null
                ? new HealthController(healthConfig, 
                AddHealthStatusBarView(GameUIController.EnemyHealthBars), _view)
                : new HealthController(healthConfig, shieldConfig, 
                AddHealthShieldStatusBarView(GameUIController.EnemyHealthBars), _view);
            
            healthController.SubscribeToOnDestroy(Dispose);
            AddController(healthController);*/

            var enemyHealthUIController = new EnemyHealthUIController(/*healthController,*/ _view);
            AddController(enemyHealthUIController);
            return enemyHealthUIController;
        }

        private HealthStatusBarView AddHealthStatusBarView(Transform transform)
        {
            var enemyStatusBarView = ResourceLoader.LoadPrefabAsChild<HealthStatusBarView>
                (_enemyHealthStatusBarCanvasPath, transform);
            AddGameObject(enemyStatusBarView.gameObject);
            return enemyStatusBarView;
        }
        
        private HealthShieldStatusBarView AddHealthShieldStatusBarView(Transform transform)
        {
            var enemyStatusBarView = ResourceLoader.LoadPrefabAsChild<HealthShieldStatusBarView>(_enemyHealthShieldStatusBarCanvasPath, transform);
            AddGameObject(enemyStatusBarView.gameObject);
            return enemyStatusBarView;
        }
    }
}