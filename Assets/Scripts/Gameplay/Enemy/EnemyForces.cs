using Gameplay.Enemy.Scriptables;
using Gameplay.Mechanics.Timer;
using Gameplay.Space.Generator;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities.Mathematics;
using Utilities.Unity;
using Random = UnityEngine.Random;

namespace Gameplay.Enemy
{
    public sealed class EnemyForces : IDisposable
    {
        private readonly Updater _updater;
        private readonly TimerFactory _timerFactory;
        private readonly int _enemyGroupCount;

        public List<Enemy> Enemies { get; private set; } = new();
        
        private readonly List<Timer> _timers = new();

        public EnemyForces(
            Updater updater,
            TimerFactory timerFactory,
            int enemyGroupCount,
            EnemySpawnConfig enemySpawnConfig,
            SpawnPointsFinder spawnPointsFinder,
            EnemyFactory enemyFactory)
        {
            _updater = updater;
            _timerFactory = timerFactory;
            _enemyGroupCount = enemyGroupCount;

            for (int i = 0; i < _enemyGroupCount; i++)
            {
                var group = RandomPicker.PickOneElementByWeights(enemySpawnConfig.Groups);
                var enemyCount = group.Squads.Sum(x => x.EnemyCount);

                _timers.Add(_timerFactory.Create(group.TimeToPickNewDirectionInSeconds));

                if (!spawnPointsFinder.TryGetEnemySpawnPoint(enemyCount, out var spawnPoint))
                {
                    Debug.Log("Enemy spawn point not found");
                    continue;
                }

                foreach (var squadConfig in group.Squads)
                {
                    for (int j = 0; j < squadConfig.EnemyCount; j++)
                    {
                        var enemyConfig = RandomPicker.PickOneElementByWeights(squadConfig.EnemyTypes);
                        var unitSize = enemyConfig.Prefab.transform.localScale;
                        var spawnCircleRadius = squadConfig.EnemyCount * 2;

                        var unitSpawnPoint = UnityHelper.GetEmptySpawnPoint(spawnPoint, unitSize, spawnCircleRadius);

                        var enemy = enemyFactory.Create(i, unitSpawnPoint, enemyConfig);
                        enemy.EnemyDestroyed += OnDeath;
                        Enemies.Add(enemy);
                    }
                }
            }

            _updater.SubscribeToUpdate(PickRandomDirection);
        }

        private void OnDeath(Enemy enemy)
        {
            enemy.EnemyDestroyed -= OnDeath;
            Enemies.Remove(enemy);
        }

        public void Dispose()
        {
            foreach (var timer in _timers)
            {
                timer.Dispose();
            }

            _timers.Clear();
            Enemies.Clear();
            _updater.UnsubscribeFromUpdate(PickRandomDirection);
        }

        private void PickRandomDirection()
        {
            for (int i = 0; i < _enemyGroupCount; i++)
            {
                if (_timers[i].InProgress)
                {
                    continue;
                }

                var direction = Random.insideUnitCircle;

                foreach (var enemy in Enemies)
                {
                    if(enemy.GroupNumber == i)
                    {
                        enemy.SetMovementDirection(direction);
                    }
                }

                _timers[i].Start();
            }
        }
    }
}