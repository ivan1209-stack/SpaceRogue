using System;
using Gameplay.Factories;
using Gameplay.Player;
using Gameplay.Space.Generator;
using Gameplay.Space.Obstacle;
using Scriptables;
using Scriptables.Enemy;
using Scriptables.Space;

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

        public LevelPreset CurrentLevelPreset { get; private set; }

        public int CurrentLevelNumber { get; private set; }
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

            _spaceView = spaceViewFactory.Create();

            var map = new MapGenerator(CurrentLevelPreset.SpaceConfig);
            map.Generate();
            
            var levelMap = new LevelMap(_spaceView, CurrentLevelPreset.SpaceConfig, map.BorderMap, map.NebulaMap);
            levelMap.Draw();

            MapCameraSize = levelMap.GetMapCameraSize();

            var spawnPointsFinder = new SpawnPointsFinder(map.NebulaMap, _spaceView.NebulaTilemap);

            spaceObstacleFactory.Create(_spaceView.SpaceObstacleView, CurrentLevelPreset.SpaceConfig.ObstacleForce);

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
            CurrentLevelPreset = _levelPresetsConfig.Presets[index];
        }
    }
}