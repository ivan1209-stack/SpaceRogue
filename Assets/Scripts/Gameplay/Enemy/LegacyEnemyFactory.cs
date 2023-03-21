using Gameplay.Enemy.Scriptables;
using Gameplay.Player;
using UnityEngine;

namespace Gameplay.Enemy
{
    public sealed class LegacyEnemyFactory
    {
        private readonly LegacyEnemyConfig _config;
        
        public LegacyEnemyFactory(LegacyEnemyConfig config)
        {
            _config = config;
        }

        public EnemyController CreateEnemy(Vector3 spawnPosition, PlayerController playerController) 
            => new(_config, CreateEnemyView(spawnPosition), playerController, playerController.View.transform);

        public EnemyController CreateEnemy(Vector3 spawnPosition, PlayerController playerController, Transform target) 
            => new(_config, CreateEnemyView(spawnPosition), playerController, target);

        private EnemyView CreateEnemyView(Vector3 spawnPosition) =>
            Object.Instantiate(_config.Prefab, spawnPosition, Quaternion.identity);
    }
}