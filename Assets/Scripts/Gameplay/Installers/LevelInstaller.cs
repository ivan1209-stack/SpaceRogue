using Gameplay.Factories;
using Gameplay.Services;
using Gameplay.Space.Factories;
using Gameplay.Space.Generator;
using Gameplay.Space.Obstacle;
using Scriptables;
using Scriptables.Enemy;
using Scriptables.Space;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public sealed class LevelInstaller : MonoInstaller
    {
        [field: SerializeField] public SpaceView SpaceViewPrefab { get; private set; }
        [field: SerializeField] public LevelPresetsConfig LevelPresetsConfig { get; private set; }

        [field: SerializeField] public StarSpawnConfig StarSpawnConfig { get; private set; }
        [field: SerializeField] public PlanetSpawnConfig PlanetSpawnConfig { get; private set; }
        [field: SerializeField] public EnemySpawnConfig EnemySpawnConfig { get; private set; }

        public override void InstallBindings()
        {
            InstallSpaceView();
            InstallLevel();
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
                .WhenInjectedInto<Level>();

            Container
                .Bind<StarSpawnConfig>()
                .FromInstance(StarSpawnConfig)
                .WhenInjectedInto<Level>();

            Container
                .Bind<PlanetSpawnConfig>()
                .FromInstance(PlanetSpawnConfig)
                .WhenInjectedInto<Level>();
            
            Container
                .Bind<EnemySpawnConfig>()
                .FromInstance(EnemySpawnConfig)
                .WhenInjectedInto<Level>();

            Container
                .BindFactory<int, Level, LevelFactory>()
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