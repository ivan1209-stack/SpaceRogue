using Gameplay.Enemy.Scriptables;
using Gameplay.Mechanics.Timer;
using Gameplay.Space.Generator;
using Services;
using Zenject;

namespace Gameplay.Enemy
{
    public sealed class EnemyForcesFactory : PlaceholderFactory<int, SpawnPointsFinder, EnemyForces>
    {
        private readonly Updater _updater;
        private readonly TimerFactory _timerFactory;
        private readonly EnemySpawnConfig _enemySpawnConfig;
        private readonly EnemyFactory _enemyFactory;

        public EnemyForcesFactory(Updater updater, TimerFactory timerFactory, EnemySpawnConfig enemySpawnConfig, EnemyFactory enemyFactory)
        {
            _updater = updater;
            _timerFactory = timerFactory;
            _enemySpawnConfig = enemySpawnConfig;
            _enemyFactory = enemyFactory;
        }

        public override EnemyForces Create(int enemyGroupCount, SpawnPointsFinder spawnPointsFinder)
        {
            return new(_updater, _timerFactory, enemyGroupCount, _enemySpawnConfig, spawnPointsFinder, _enemyFactory);
        }
    }
}