using System;
using Gameplay.Enemy;

namespace Gameplay.Services
{
    public sealed class Level : IDisposable
    {
        private readonly Player.Player _player;
        private readonly EnemyForces _enemyForces;
        private readonly Space.Space _space;

        public int CurrentLevelNumber { get; private set; }
        public int EnemiesCountToWin { get; private set; }
        public int EnemiesCreatedCount { get; private set; }
        public float MapCameraSize { get; private set; }

        public Level(
            int currentLevelNumber,
            int enemiesCountToWin,
            float mapCameraSize,
            Player.Player player,
            EnemyForces enemyForces,
            Space.Space space)
        {
            CurrentLevelNumber = currentLevelNumber;
            EnemiesCountToWin = enemiesCountToWin;
            MapCameraSize = mapCameraSize;
            _player = player;
            _enemyForces = enemyForces;
            _space = space;
            EnemiesCreatedCount = _enemyForces.Enemies.Count;
        }

        public void Dispose()
        {
            _player.Dispose();
            _enemyForces.Dispose();
            _space.Dispose();
        }
    }
}