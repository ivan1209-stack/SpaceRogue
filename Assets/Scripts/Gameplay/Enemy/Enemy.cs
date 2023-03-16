using System;
using Gameplay.Enemy.Scriptables;
using Gameplay.Survival;
using UnityEngine;

namespace Gameplay.Enemy
{
    public sealed class Enemy : IDisposable
    {
        private readonly EnemyConfig _enemyConfig;

        public EnemyView EnemyView { get; }
        public EntitySurvival Survival { get; }

        public Enemy(
            Vector2 spawnPoint,
            EnemyConfig enemyConfig,
            EnemyViewFactory enemyViewFactory)
        {
            _enemyConfig = enemyConfig;
            EnemyView = enemyViewFactory.Create(spawnPoint, enemyConfig);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(EnemyView);
        }
    }
}