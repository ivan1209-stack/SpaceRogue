using System;
using Gameplay.Factories;
using Gameplay.Space.Generator;
using Gameplay.Space.Obstacle;
using Scriptables;
using Scriptables.Enemy;
using Scriptables.Space;

namespace Gameplay.Services
{
    public class Level : IDisposable
    {
        private readonly SpaceView _spaceView;
        private readonly LevelPresetsConfig _levelPresetsConfig;
        private readonly StarSpawnConfig _starSpawnConfig;
        private readonly PlanetSpawnConfig _planetSpawnConfig;
        private readonly EnemySpawnConfig _enemySpawnConfig;
        private readonly LevelGenerator _levelGenerator;

        private LevelPreset _currentLevelPreset;

        public int CurrentLevelNumber { get; private set; }

        public Level(int currentLevelNumber, SpaceViewFactory spaceViewFactory, LevelPresetsConfig levelPresetsConfig, StarSpawnConfig starSpawnConfig, PlanetSpawnConfig planetSpawnConfig, EnemySpawnConfig enemySpawnConfig, SpaceObstacleFactory spaceObstacleFactory)
        {
            CurrentLevelNumber = currentLevelNumber;
            _levelPresetsConfig = levelPresetsConfig;
            _starSpawnConfig = starSpawnConfig;
            _planetSpawnConfig = planetSpawnConfig;
            _enemySpawnConfig = enemySpawnConfig;
            PickRandomLevelPreset();

            _spaceView = spaceViewFactory.Create();
            
            //TODO Remade Generator
            _levelGenerator = new(_spaceView, _currentLevelPreset.SpaceConfig, starSpawnConfig, enemySpawnConfig);
            _levelGenerator.Generate();

            spaceObstacleFactory.Create(_spaceView.SpaceObstacleView, _currentLevelPreset.SpaceConfig.ObstacleForce);

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