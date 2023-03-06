using Abstracts;
using Gameplay.Health;
using Gameplay.Input;
using Gameplay.Movement;
using Gameplay.Player.FrontalGuns;
using Gameplay.Player.Inventory;
using Gameplay.Player.Movement;
using Scriptables;
using Scriptables.Health;
using Scriptables.Modules;
using System;
using System.Collections.Generic;
using UI.Game;
using UnityEngine;
using Utilities.Reactive.SubscriptionProperty;
using Utilities.ResourceManagement;

namespace Gameplay.Player
{
    public sealed class PlayerController : BaseController
    {
        public PlayerView View => _view;

        private readonly ResourcePath _configPath = new(Constants.Configs.Player.PlayerConfig);
        private readonly ResourcePath _viewPath = new(Constants.Prefabs.Gameplay.Player);
        private readonly ResourcePath _crosshairPrefabPath = new(Constants.Prefabs.Stuff.Crosshair);

        private readonly PlayerConfig _config;
        private readonly PlayerView _view;

        private readonly SubscribedProperty<Vector3> _mousePositionInput = new();
        private readonly SubscribedProperty<float> _verticalInput = new();
        private readonly SubscribedProperty<bool> _primaryFireInput = new();
        private readonly SubscribedProperty<bool> _changeWeaponInput = new ();

        //private readonly HealthController _healthController;

        public event Action PlayerDestroyed = () => { };
        public event Action OnControllerDispose = () => { };
        public SubscribedProperty<bool> NextLevelInput = new ();
        public SubscribedProperty<bool> MapInput = new ();

        public PlayerController(Vector3 playerPosition, HealthInfo healthInfo, ShieldInfo shieldInfo)
        {
            _config = ResourceLoader.LoadObject<PlayerConfig>(_configPath);
            _view = LoadView<PlayerView>(_viewPath, playerPosition);

            /*var inputController = new InputController(_mousePositionInput, _verticalInput, _primaryFireInput, 
                _changeWeaponInput, NextLevelInput, MapInput);
            AddController(inputController);*/

            //var inventoryController = AddInventoryController(_config.Inventory);
            //var movementController = AddMovementController(_config.Movement, _view);
            var frontalGunsController = AddFrontalGunsController(new List<TurretModuleConfig>(), _view);
            //_healthController = AddHealthController(healthInfo, shieldInfo);
            //AddCrosshair();
        }
        

        public void ControllerDispose()
        {
            OnControllerDispose.Invoke();
            Dispose();
        }

        private FrontalGunsController AddFrontalGunsController(List<TurretModuleConfig> turretConfigs, PlayerView view)
        {
            var frontalGunsController = new FrontalGunsController(_primaryFireInput, _changeWeaponInput, turretConfigs, view);
            AddController(frontalGunsController);
            return frontalGunsController;
        }

    }
}