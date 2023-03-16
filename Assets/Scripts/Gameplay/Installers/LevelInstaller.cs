using Gameplay.Enemy;
using Gameplay.Enemy.Scriptables;
using Gameplay.LevelProgress;
using Gameplay.Services;
using Gameplay.Space.Factories;
using Gameplay.Space.Generator;
using Gameplay.Space.Obstacle;
using Gameplay.Space.SpaceObjects.Scriptables;
using Scriptables;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace Gameplay.Installers
{
    public sealed class LevelInstaller : MonoInstaller
    {
        [field: SerializeField] public SpaceView SpaceViewPrefab { get; private set; }
        [field: SerializeField] public LevelPresetsConfig LevelPresetsConfig { get; private set; }

        [field: SerializeField] public StarSpawnConfig StarSpawnConfig { get; private set; }
        [field: SerializeField] public PlanetSpawnConfig PlanetSpawnConfig { get; private set; }

        public override void InstallBindings()
        {
            InstallSpaceView();
            InstallLevel();
            InstallLevelGenerator();
            InstallSpaceObstacle();
            InstallLevelProgressService();
        }

        private void InstallSpaceView()
        {
            Container
                .Bind<SpaceView>()
                .FromInstance(SpaceViewPrefab)
                .WhenInjectedInto<SpaceViewFactory>();

            Container
                .BindFactory<SpaceView, SpaceViewFactory>()
                .AsSingle();
        }

        private void InstallLevel()
        {
            Container
                .Bind<LevelPresetsConfig>()
                .FromInstance(LevelPresetsConfig)
                .WhenInjectedInto<LevelFactory>();

            Container
                .Bind<StarSpawnConfig>()
                .FromInstance(StarSpawnConfig)
                .WhenInjectedInto<LevelFactory>();

            Container
                .Bind<PlanetSpawnConfig>()
                .FromInstance(PlanetSpawnConfig)
                .WhenInjectedInto<LevelFactory>();

            Container
                .BindFactory<int, Level, LevelFactory>()
                .AsSingle();
        }

        private void InstallLevelGenerator()
        {
            Container
                .BindFactory<SpaceConfig, MapGenerator, MapGeneratorFactory>()
                .AsSingle();
            
            Container
                .BindFactory<SpaceView, SpaceConfig, int[,], int[,], LevelMap, LevelMapFactory>()
                .AsSingle();
            
            Container
                .BindFactory<int[,], Tilemap, SpawnPointsFinder, SpawnPointsFinderFactory>()
                .AsSingle();
        }
        
        private void InstallSpaceObstacle()
        {
            Container
                .BindFactory<SpaceObstacleView, float, SpaceObstacle, SpaceObstacleFactory>()
                .AsSingle();
        }

        private void InstallLevelProgressService()
        {
            Container
                .BindInterfacesAndSelfTo<CurrentLevelProgress>()
                .AsSingle()
                .NonLazy();
        }
    }
}