using UnityEngine;
using Zenject;
using Gameplay.Enemy.Scriptables;
using Gameplay.Pooling;

namespace Gameplay.Enemy
{
    public sealed class EnemyViewFactory : PlaceholderFactory<Vector2, EnemyConfig, EnemyView>
    {
        private readonly EnemyPool _enemyPool;
        private readonly DiContainer _diContainer;

        public EnemyViewFactory(EnemyPool enemyPool, DiContainer diContainer)
        {
            _enemyPool = enemyPool;
            _diContainer = diContainer;
        }

        public override EnemyView Create(Vector2 position, EnemyConfig config)
        {
            return _diContainer.InstantiatePrefabForComponent<EnemyView>(config.Prefab, position, Quaternion.identity, _enemyPool.transform);
        }
    }
}