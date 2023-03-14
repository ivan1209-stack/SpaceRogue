using System;
using Gameplay.Player;
using Gameplay.Space.Factories;
using Gameplay.Space.Generator;
using Gameplay.Space.Obstacle;
using Gameplay.Space.SpaceObjects.Scriptables;
using Scriptables;
using Scriptables.Enemy;

namespace Gameplay.Services
{
    public sealed class Level : IDisposable
    {
        private readonly SpaceView _spaceView;
        private readonly PlayerFactory _playerFactory;
        private readonly LevelPresetsConfig _levelPresetsConfig;
        private readonly StarSpawnConfig _starSpawnConfig;
        private readonly PlanetSpawnConfig _planetSpawnConfig;
        private readonly EnemySpawnConfig _enemySpawnConfig;

        private LevelPreset _currentLevelPreset;

        public int CurrentLevelNumber { get; private set; }
        public int EnemiesCountToWin { get; private set; }
        public int EnemiesCreatedCount { get; private set; }
        public float MapCameraSize { get; private set; }

        public Level(
            int currentLevelNumber,
            SpaceViewFactory spaceViewFactory,
            PlayerFactory playerFactory,
            LevelPresetsConfig levelPresetsConfig,
            StarSpawnConfig starSpawnConfig,
            PlanetSpawnConfig planetSpawnConfig,
            EnemySpawnConfig enemySpawnConfig,
            SpaceObstacleFactory spaceObstacleFactory)
        {
            CurrentLevelNumber = currentLevelNumber;
            _playerFactory = playerFactory;
            _levelPresetsConfig = levelPresetsConfig;
            _starSpawnConfig = starSpawnConfig;
            _planetSpawnConfig = planetSpawnConfig;
            _enemySpawnConfig = enemySpawnConfig;
            
            PickRandomLevelPreset();
            EnemiesCountToWin = _currentLevelPreset.EnemiesCountToWin;

            _spaceView = spaceViewFactory.Create();

            var map = new MapGenerator(_currentLevelPreset.SpaceConfig);
            map.Generate();
            
            var levelMap = new LevelMap(_spaceView, _currentLevelPreset.SpaceConfig, map.BorderMap, map.NebulaMap);
            levelMap.Draw();

            MapCameraSize = levelMap.GetMapCameraSize();

            var spawnPointsFinder = new SpawnPointsFinder(map.NebulaMap, _spaceView.NebulaTilemap);

            spaceObstacleFactory.Create(_spaceView.SpaceObstacleView, _currentLevelPreset.SpaceConfig.ObstacleForce);

            _playerFactory.Create(spawnPointsFinder.GetPlayerSpawnPoint());

            EnemiesCreatedCount = 1000;
            //TODO
            //View Factory & Service Factory
            //SpaceObjectFactory OR StarsFactory & PlanetFactory
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(_spaceView);
        }

        private void PickRandomLevelPreset()
        {
            var index = new Random().Next(_levelPresetsConfig.Presets.Count);
            _currentLevelPreset = _levelPresetsConfig.Presets[index];
        }
    }
}