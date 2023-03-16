using System;
using Gameplay.Enemy;
using Gameplay.Space.Generator;

namespace Gameplay.Services
{
    public sealed class Level : IDisposable
    {
        private readonly SpaceView _spaceView;
        private readonly Player.Player _player;
        private readonly EnemyForces _enemyForces;

        public int CurrentLevelNumber { get; private set; }
        public int EnemiesCountToWin { get; private set; }
        public int EnemiesCreatedCount { get; private set; }
        public float MapCameraSize { get; private set; }

        public Level(
            int currentLevelNumber,
            int enemiesCountToWin,
            SpaceView spaceView,
            float mapCameraSize,
            Player.Player player,
            EnemyForces enemyForces)
        {
            CurrentLevelNumber = currentLevelNumber;
            EnemiesCountToWin = enemiesCountToWin;
            _spaceView = spaceView;
            MapCameraSize = mapCameraSize;
            _player = player;
            _enemyForces = enemyForces;
            EnemiesCreatedCount = _enemyForces.Enemies.Count;
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(_spaceView.gameObject);
        }
    }
}