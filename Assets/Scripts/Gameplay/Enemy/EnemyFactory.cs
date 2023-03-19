using Gameplay.Enemy.Scriptables;
using Gameplay.Survival;
using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Enemy
{
    public sealed class EnemyFactory : PlaceholderFactory<Vector2, EnemyConfig, Enemy>
    {
        private readonly EnemyViewFactory _enemyViewFactory;
        private readonly EntitySurvivalFactory _entitySurvivalFactory;

        public event Action<Enemy> EnemyCreated = _ => { };

        public EnemyFactory(EnemyViewFactory enemyViewFactory, EntitySurvivalFactory entitySurvivalFactory)
        {
            _enemyViewFactory = enemyViewFactory;
            _entitySurvivalFactory = entitySurvivalFactory;
        }

        public override Enemy Create(Vector2 spawnPoint, EnemyConfig enemyConfig)
        {
            var enemyView = _enemyViewFactory.Create(spawnPoint, enemyConfig);
            var enemySurvival = _entitySurvivalFactory.Create(enemyConfig.Survival);
            var enemy = new Enemy(enemyView, enemySurvival);
            EnemyCreated.Invoke(enemy);
            return enemy;
        }
    }
}