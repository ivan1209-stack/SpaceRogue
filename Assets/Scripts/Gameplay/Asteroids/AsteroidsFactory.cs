using Gameplay.Space.Generator;
using Zenject;

namespace Asteroids
{
    public class AsteroidsFactory : PlaceholderFactory<int, SpawnPointsFinder, AsteroidObjects>
    {
        private readonly AsteroidSpawnConfig _config;
        private readonly AsteroidFactory _asteroidFactory;

        public AsteroidsFactory(AsteroidSpawnConfig config, AsteroidFactory asteroidFactory)
        {
            _config = config;
            _asteroidFactory = asteroidFactory;
        }

        public override AsteroidObjects Create(int asteroidsSpawnOnStartCount, SpawnPointsFinder spawnPointsFinder)
        {
            return new(asteroidsSpawnOnStartCount, _config, spawnPointsFinder, _asteroidFactory);
        }
    }
}