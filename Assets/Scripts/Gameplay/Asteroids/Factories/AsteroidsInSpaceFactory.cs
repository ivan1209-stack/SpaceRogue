using Gameplay.Asteroids.Scriptables;
using Gameplay.Space.Generator;
using Zenject;

namespace Gameplay.Asteroids.Factories
{
    public class AsteroidsInSpaceFactory : PlaceholderFactory<int, SpawnPointsFinder, AsteroidsInSpace>
    {
        private readonly AsteroidSpawnConfig _config;
        private readonly AsteroidFactory _asteroidFactory;

        public AsteroidsInSpaceFactory(AsteroidSpawnConfig config, AsteroidFactory asteroidFactory)
        {
            _config = config;
            _asteroidFactory = asteroidFactory;
        }

        public override AsteroidsInSpace Create(int asteroidsSpawnOnStartCount, SpawnPointsFinder spawnPointsFinder)
        {
            return new(asteroidsSpawnOnStartCount, _config, spawnPointsFinder, _asteroidFactory);
        }
    }
}