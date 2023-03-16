using Gameplay.Enemy.Scriptables;
using UnityEngine;
using Zenject;

namespace Gameplay.Enemy
{
    public sealed class EnemyFactory : PlaceholderFactory<Vector2, EnemyConfig, Enemy>
    {
        private readonly EnemyViewFactory _enemyViewFactory;

        public EnemyFactory(EnemyViewFactory enemyViewFactory)
        {
            _enemyViewFactory = enemyViewFactory;
        }

        public override Enemy Create(Vector2 spawnPoint, EnemyConfig enemyConfig)
        {
            var enemyView = _enemyViewFactory.Create(spawnPoint, enemyConfig);
            return new(enemyView);
        }
    }
}