using Gameplay.Enemy.Scriptables;
using Gameplay.Space.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities.Mathematics;
using Utilities.Unity;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace Gameplay.Enemy
{
    public sealed class EnemyForces : IDisposable
    {
        private const byte MaxCountSpawnTries = 10;

        private readonly int _enemyGroupCount;
        private readonly EnemySpawnConfig _enemySpawnConfig;
        private readonly SpawnPointsFinder _spawnPointsFinder;
        private readonly EnemyFactory _enemyFactory;
        private readonly System.Random _random;

        public List<Enemy> Enemies { get; private set; } = new();

        public EnemyForces(int enemyGroupCount, EnemySpawnConfig enemySpawnConfig, SpawnPointsFinder spawnPointsFinder, EnemyFactory enemyFactory)
        {
            _enemyGroupCount = enemyGroupCount;
            _enemySpawnConfig = enemySpawnConfig;
            _spawnPointsFinder = spawnPointsFinder;
            _enemyFactory = enemyFactory;
            _random = new System.Random();

            for (int i = 0; i < _enemyGroupCount; i++)
            {
                var group = RandomPicker.PickOneElementByWeights(_enemySpawnConfig.Groups, _random);
                var enemyCount = group.Squads.Sum(x => x.EnemyCount);

                if (!_spawnPointsFinder.TryGetEnemySpawnPoint(enemyCount, out var spawnPoint))
                {
                    Debug.Log("Not Found point");
                    continue;
                }

                foreach (var squadConfig in group.Squads)
                {
                    for (int j = 0; j < squadConfig.EnemyCount; j++)
                    {
                        var enemyConfig = RandomPicker.PickOneElementByWeights(squadConfig.EnemyTypes, _random);
                        var unitSize = enemyConfig.Prefab.transform.localScale;
                        var spawnCircleRadius = squadConfig.EnemyCount * 2;

                        var unitSpawnPoint = GetEmptySpawnPoint(spawnPoint, unitSize, spawnCircleRadius);

                        var enemy = _enemyFactory.Create(unitSpawnPoint, enemyConfig);
                        Enemies.Add(enemy);
                    }
                }
            }
        }

        public void Dispose()
        {
            Enemies.Clear();
        }

        private Vector3 GetEmptySpawnPoint(Vector3 spawnPoint, Vector3 unitSize, int spawnCircleRadius)
        {
            var unitSpawnPoint = spawnPoint + (Vector3)(Random.insideUnitCircle * spawnCircleRadius);
            var unitMaxSize = unitSize.MaxVector3CoordinateOnPlane();

            var tryCount = 0;
            while (UnityHelper.IsAnyObjectAtPosition(unitSpawnPoint, unitMaxSize) && tryCount <= MaxCountSpawnTries)
            {
                unitSpawnPoint = spawnPoint + (Vector3)(Random.insideUnitCircle * spawnCircleRadius);
                tryCount++;
            }

            return unitSpawnPoint;
        }
    }
}