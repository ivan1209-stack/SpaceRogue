using Gameplay.Space.Generator;
using UnityEngine;
using Zenject;

namespace Asteroids
{
    public class AsteroidsInstaller : MonoInstaller
    {
        [field: SerializeField] public AsteroidSpawnConfig AsteroidSpawnConfig { get; private set; }
        [field: SerializeField] public AsteroidsPool Pool { get; private set; }

        public override void InstallBindings()
        {
            InstallAsteroidsPool();
            InstallAsteroidsFactory();
            InstallAsteroidFactory();
            InstallAsteroidViewFactory();
            InstallAsteroidMovementFactory();
        }

        private void InstallAsteroidMovementFactory()
        {
            Container.BindFactory<AsteroidMoveConfig, AsteroidView, Vector2, AsteroidMovement, AsteroidMovementFactory>().AsSingle();
        }

        private void InstallAsteroidViewFactory()
        {
            Container.BindFactory<Vector2, AsteroidConfig, AsteroidView, AsteroidViewFactory>().AsSingle();
        }

        private void InstallAsteroidFactory()
        {
            Container.BindFactory<Vector2, Vector2, AsteroidConfig, Asteroid, AsteroidFactory>().AsSingle();
        }

        private void InstallAsteroidsFactory()
        {
            Container.Bind<AsteroidSpawnConfig>().FromInstance(AsteroidSpawnConfig).WhenInjectedInto<AsteroidsFactory>();
            Container.BindFactory<int, SpawnPointsFinder, AsteroidObjects, AsteroidsFactory>().AsSingle();
        }

        private void InstallAsteroidsPool()
        {
            Container.Bind<AsteroidsPool>().FromInstance(Pool).AsSingle();
        }
    }
}