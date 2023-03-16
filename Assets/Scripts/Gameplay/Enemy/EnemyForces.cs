using Gameplay.Enemy.Scriptables;
using Gameplay.Space.Generator;
using System;
using System.Collections.Generic;
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
        private readonly EnemyGroupConfig _enemyGroupConfig;
        private readonly SpawnPointsFinder _spawnPointsFinder;
        private readonly EnemyFactory _enemyFactory;
        private readonly System.Random _random;

        public List<Enemy> Enemies { get; private set; } = new();

        public EnemyForces(int enemyGroupCount,  EnemyGroupConfig enemyGroupConfig, SpawnPointsFinder spawnPointsFinder, EnemyFactory enemyFactory)
        {
            _enemyGroupCount = enemyGroupCount;
            _enemyGroupConfig = enemyGroupConfig;
            _spawnPointsFinder = spawnPointsFinder;
            _enemyFactory = enemyFactory;
            _random = new System.Random();

            for (int i = 0; i < _enemyGroupCount; i++)
            {
                var squad = RandomPicker.PickOneElementByWeights(_enemyGroupConfig.Squads, _random);
                
                if (!_spawnPointsFinder.TryGetEnemySpawnPoint(squad.EnemyCount, out var spawnPoint))
                {
                    Debug.Log("Not Found point");
                    continue;
                }

                for (int j = 0; j < squad.EnemyCount; j++)
                {
                    var enemyConfig = RandomPicker.PickOneElementByWeights(squad.EnemyTypes, _random);
                    var unitSize = enemyConfig.Prefab.transform.localScale;
                    var spawnCircleRadius = squad.EnemyCount * 2;

                    var unitSpawnPoint = GetEmptySpawnPoint(spawnPoint, unitSize, spawnCircleRadius);

                    var enemy = _enemyFactory.Create(unitSpawnPoint, enemyConfig);
                    Enemies.Add(enemy);
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