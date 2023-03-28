using Gameplay.Enemy.Movement;
using Gameplay.Enemy.Scriptables;
using Gameplay.Movement;
using Gameplay.Survival;
using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Enemy
{
    public sealed class EnemyFactory : PlaceholderFactory<Vector2, EnemyConfig, Enemy>
    {
        private readonly EnemyViewFactory _enemyViewFactory;
        private readonly EnemyInputFactory _enemyInputFactory;
        private readonly UnitMovementModelFactory _unitMovementModelFactory;
        private readonly EnemyMovementFactory _enemyMovementFactory;
        private readonly EnemyTurningFactory _enemyTurningFactory;
        private readonly EntitySurvivalFactory _entitySurvivalFactory;

        public event Action<Enemy> EnemyCreated = _ => { };

        public EnemyFactory(
            EnemyViewFactory enemyViewFactory, 
            EnemyInputFactory enemyInputFactory,
            UnitMovementModelFactory unitMovementModelFactory,
            EnemyMovementFactory enemyMovementFactory,
            EnemyTurningFactory enemyTurningFactory,
            EntitySurvivalFactory entitySurvivalFactory)
        {
            _enemyViewFactory = enemyViewFactory;
            _enemyInputFactory = enemyInputFactory;
            _unitMovementModelFactory = unitMovementModelFactory;
            _enemyMovementFactory = enemyMovementFactory;
            _enemyTurningFactory = enemyTurningFactory;
            _entitySurvivalFactory = entitySurvivalFactory;
        }

        public override Enemy Create(Vector2 spawnPoint, EnemyConfig enemyConfig)
        {
            var enemyView = _enemyViewFactory.Create(spawnPoint, enemyConfig);
            var enemyInput = _enemyInputFactory.Create();
            var model = _unitMovementModelFactory.Create(enemyConfig.Movement);
            var enemyMovement = _enemyMovementFactory.Create(enemyView, enemyInput, model);
            var enemyTurning = _enemyTurningFactory.Create(enemyView, enemyInput, model);
            var enemySurvival = _entitySurvivalFactory.Create(enemyConfig.Survival);
            var enemy = new Enemy(enemyView, enemyMovement, enemyTurning, enemySurvival);
            EnemyCreated.Invoke(enemy);
            return enemy;
        }
    }
}