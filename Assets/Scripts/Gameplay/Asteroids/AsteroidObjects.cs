using Gameplay.Space.Generator;
using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities.Mathematics;

namespace Asteroids
{
    public class AsteroidObjects : IDisposable
    {
        private readonly SpawnPointsFinder _spawnPointsFinder;
        private readonly AsteroidFactory _asteroidFactory;

        private const int MaxSpawnTriesPerAsteroid = 5;
        private const int MaxTriesToCreateStartAsteroids = 100;

        public List<Asteroid> Asteroids { get; private set; } = new();

        public AsteroidObjects(
            int asteroidsOnStartCount, 
            AsteroidSpawnConfig asteroidSpawnConfig, 
            SpawnPointsFinder spawnPointsFinder, 
            AsteroidFactory asteroidFactory)
        {
            _spawnPointsFinder = spawnPointsFinder;
            _asteroidFactory = asteroidFactory;

            SpawnStartAsteroids(asteroidsOnStartCount, asteroidSpawnConfig);
        }

        public void Dispose()
        {
            for (int i = 0; i < Asteroids.Count; i++) Asteroids[i].Dispose();
            Asteroids.Clear();
        }

        private void SpawnStartAsteroids(int asteroidsOnStartCount, AsteroidSpawnConfig asteroidSpawnConfig)
        {
            var tryCount = 0;
            do
            {
                TrySpawnAsteroid(asteroidSpawnConfig);
                tryCount++;
            }
            while (Asteroids.Count < asteroidsOnStartCount || tryCount < MaxTriesToCreateStartAsteroids);
        }

        private void TrySpawnAsteroid(AsteroidSpawnConfig config)
        {
            var newAsteroidConfig = RandomPicker.PickOneElementByWeights(config.AsteroidPrefabs);
            var asteroidRadius = newAsteroidConfig.Prefab.Collider.radius;
            var asteroidSpawnOrbit = RandomPicker.PickRandomBetweenTwoValues(0, newAsteroidConfig.MaxSpawnOrbit);
            var spawnTries = 0;
            do
            {
                if (_spawnPointsFinder.TryGetSpaceObjectSpawnPoint(asteroidRadius, asteroidSpawnOrbit, out var spawnPoint))
                {
                    var newAsteroid = _asteroidFactory.Create(spawnPoint, Vector2.zero, newAsteroidConfig);
                    Asteroids.Add(newAsteroid);
                    return;
                }
                else spawnTries++;
            } 
            while (spawnTries < MaxSpawnTriesPerAsteroid);
        }
    }
}