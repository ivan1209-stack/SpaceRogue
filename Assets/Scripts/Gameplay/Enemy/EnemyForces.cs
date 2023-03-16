using Gameplay.Enemy.Scriptables;
using Gameplay.Space.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities.Mathematics;
using Utilities.Unity;

namespace Gameplay.Enemy
{
    public sealed class EnemyForces : IDisposable
    {
        public List<Enemy> Enemies { get; private set; } = new();

        public EnemyForces(int enemyGroupCount, EnemySpawnConfig enemySpawnConfig, SpawnPointsFinder spawnPointsFinder, EnemyFactory enemyFactory)
        {
            var random = new System.Random();

            for (int i = 0; i < enemyGroupCount; i++)
            {
                var group = RandomPicker.PickOneElementByWeights(enemySpawnConfig.Groups, random);
                var enemyCount = group.Squads.Sum(x => x.EnemyCount);

                if (!spawnPointsFinder.TryGetEnemySpawnPoint(enemyCount, out var spawnPoint))
                {
                    Debug.Log("Not Found point");
                    continue;
                }

                foreach (var squadConfig in group.Squads)
                {
                    for (int j = 0; j < squadConfig.EnemyCount; j++)
                    {
                        var enemyConfig = RandomPicker.PickOneElementByWeights(squadConfig.EnemyTypes, random);
                        var unitSize = enemyConfig.Prefab.transform.localScale;
                        var spawnCircleRadius = squadConfig.EnemyCount * 2;

                        var unitSpawnPoint = UnityHelper.GetEmptySpawnPoint(spawnPoint, unitSize, spawnCircleRadius);

                        var enemy = enemyFactory.Create(unitSpawnPoint, enemyConfig);
                        Enemies.Add(enemy);
                    }
                }
            }
        }

        public void Dispose()
        {
            Enemies.Clear();
        }
    }
}