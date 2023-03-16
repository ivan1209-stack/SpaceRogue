using System;
using Gameplay.Enemy;
using Gameplay.Player;
using Gameplay.Services;
using Gameplay.Space.Factories;
using Gameplay.Space.Generator;
using Gameplay.Space.Obstacle;
using Gameplay.Space.SpaceObjects.Scriptables;
using Scriptables;
using Zenject;

namespace Gameplay.LevelProgress
{
    public sealed class LevelFactory : PlaceholderFactory<int, Level>
    {
        private readonly LevelPresetsConfig _levelPresetsConfig;
        private readonly SpaceViewFactory _spaceViewFactory;
        private readonly SpaceObstacleFactory _spaceObstacleFactory;
        private readonly PlayerFactory _playerFactory;
        private readonly StarSpawnConfig _starSpawnConfig;
        private readonly PlanetSpawnConfig _planetSpawnConfig;
        private readonly SpaceObjectFactory _spaceObjectFactory;
        private readonly EnemyForcesFactory _enemyForcesFactory;
        
        private LevelPreset _currentLevelPreset;

        public event Action<Level> LevelCreated = (_) => { };

        public LevelFactory(
            LevelPresetsConfig levelPresetsConfig,
            SpaceViewFactory spaceViewFactory,
            SpaceObstacleFactory spaceObstacleFactory,
            PlayerFactory playerFactory,
            StarSpawnConfig starSpawnConfig,
            PlanetSpawnConfig planetSpawnConfig,
            SpaceObjectFactory spaceObjectFactory,
            EnemyForcesFactory enemyForcesFactory)
        {
            _levelPresetsConfig = levelPresetsConfig;
            _spaceViewFactory = spaceViewFactory;
            _spaceObstacleFactory = spaceObstacleFactory;
            _playerFactory = playerFactory;
            _starSpawnConfig = starSpawnConfig;
            _planetSpawnConfig = planetSpawnConfig;
            _spaceObjectFactory = spaceObjectFactory;
            _enemyForcesFactory = enemyForcesFactory;
        }

        public override Level Create(int levelNumber)
        {
            PickRandomLevelPreset();
            var spaceView = _spaceViewFactory.Create();

            var map = new MapGenerator(_currentLevelPreset.SpaceConfig);
            map.Generate();

            var levelMap = new LevelMap(spaceView, _currentLevelPreset.SpaceConfig, map.BorderMap, map.NebulaMap);
            levelMap.Draw();
            var mapCameraSize = levelMap.GetMapCameraSize();

            var spawnPointsFinder = new SpawnPointsFinder(map.NebulaMap, spaceView.NebulaTilemap);

            _spaceObstacleFactory.Create(spaceView.SpaceObstacleView, _currentLevelPreset.SpaceConfig.ObstacleForce);

            var player = default(Player.Player);
            if (spawnPointsFinder.TryGetPlayerSpawnPoint(out var playerSpawnPoint))
            {
                player = _playerFactory.Create(playerSpawnPoint);
            }

            //_spaceObjectFactory

            var enemyForces = _enemyForcesFactory.Create(_currentLevelPreset.SpaceConfig.EnemyGroupCount, spawnPointsFinder);

            var level = new Level(levelNumber, _currentLevelPreset.EnemiesCountToWin, spaceView, mapCameraSize, player, enemyForces);
            LevelCreated.Invoke(level);
            return level;
        }

        private void PickRandomLevelPreset()
        {
            var index = new Random().Next(_levelPresetsConfig.Presets.Count);
            _currentLevelPreset = _levelPresetsConfig.Presets[index];
        }
    }
}