using Gameplay.Enemy.Scriptables;
using Gameplay.Space.Generator;
using Zenject;

namespace Gameplay.Enemy
{
    public sealed class EnemyForcesFactory : PlaceholderFactory<int, SpawnPointsFinder, EnemyForces>
    {
        private readonly EnemySpawnConfig _enemySpawnConfig;
        private readonly EnemyFactory _enemyFactory;

        public EnemyForcesFactory(EnemySpawnConfig enemySpawnConfig, EnemyFactory enemyFactory)
        {
            _enemySpawnConfig = enemySpawnConfig;
            _enemyFactory = enemyFactory;
        }

        public override EnemyForces Create(int enemyGroupCount, SpawnPointsFinder spawnPointsFinder)
        {
            return new(enemyGroupCount, _enemySpawnConfig, spawnPointsFinder, _enemyFactory);
        }
    }
}