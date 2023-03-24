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
            Container.Bind<AsteroidsPool>().FromInstance(Pool).AsSingle();

            Container.Bind<AsteroidSpawnConfig>().FromInstance(AsteroidSpawnConfig).WhenInjectedInto<AsteroidObjectsFactory>();
            Container.BindFactory<int, SpawnPointsFinder, AsteroidObjects, AsteroidObjectsFactory>().AsSingle();

            Container.BindFactory<Vector2, Vector2, AsteroidConfig, Asteroid, AsteroidFactory>().AsSingle();

            Container.BindFactory<Vector2, AsteroidConfig, AsteroidView, AsteroidViewFactory>().AsSingle();

            Container.BindFactory<AsteroidMoveConfig, AsteroidView, Vector2, AsteroidMovement, AsteroidMovementFactory>().AsSingle();
        }
    }
}