using System;
using Asteroids;
using Gameplay.Enemy;
using Gameplay.Space.Generator;

namespace Gameplay.Services
{
    public sealed class Level : IDisposable
    {
        private readonly SpaceView _spaceView;
        private readonly Player.Player _player;
        private readonly EnemyForces _enemyForces;
        private readonly Space.Space _space;
        private readonly AsteroidObjects _asteroids;

        public int CurrentLevelNumber { get; private set; }
        public int EnemiesCountToWin { get; private set; }
        public int EnemiesCreatedCount { get; private set; }
        public int AsteroidsCreatedOnStart { get; private set; }
        public float MapCameraSize { get; private set; }

        public Level(
            int currentLevelNumber,
            int enemiesCountToWin,
            SpaceView spaceView,
            float mapCameraSize,
            Player.Player player,
            EnemyForces enemyForces,
            Space.Space space,
            AsteroidObjects asteroids)
        {
            CurrentLevelNumber = currentLevelNumber;
            EnemiesCountToWin = enemiesCountToWin;
            _spaceView = spaceView;
            MapCameraSize = mapCameraSize;
            _player = player;
            _enemyForces = enemyForces;
            _space = space;
            EnemiesCreatedCount = _enemyForces.Enemies.Count;
            _asteroids = asteroids;
            AsteroidsCreatedOnStart = _asteroids.Asteroids.Count;
        }

        public void Dispose()
        {
            _player.Dispose();
            _enemyForces.Dispose();
            _space.Dispose();
            _asteroids.Dispose();
            UnityEngine.Object.Destroy(_spaceView.gameObject);
        }
    }
}