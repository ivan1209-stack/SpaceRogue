using Gameplay.Enemy.Scriptables;
using Gameplay.Space.Generator;
using Services;
using Zenject;

namespace Gameplay.Enemy
{
    public sealed class EnemyForcesFactory : PlaceholderFactory<int, SpawnPointsFinder, EnemyForces>
    {
        private readonly EnemyGroupConfig _enemyGroupConfig;
        private readonly EnemyFactory _enemyFactory;

        public EnemyForcesFactory(EnemyGroupConfig enemyGroupConfig, EnemyFactory enemyFactory)
        {
            _enemyGroupConfig = enemyGroupConfig;
            _enemyFactory = enemyFactory;
        }

        public override EnemyForces Create(int enemyGroupCount, SpawnPointsFinder spawnPointsFinder)
        {
            return new(enemyGroupCount, _enemyGroupConfig, spawnPointsFinder, _enemyFactory);
        }
    }
}