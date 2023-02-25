using Scriptables.Enemy;
using Scriptables.Space;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

namespace Gameplay.Space.Generator
{
    public sealed class SpawnPointsFinder
    {
        private readonly int _starCount;
        private readonly int _starRadius;

        private readonly int _enemyCount;
        private readonly int _enemyRadius;

        private readonly int[,] _map;
        private readonly Tilemap _tilemap;
        private readonly int[,] _spaceObjectsMap;

        private List<Point> _availablePoints = new();

        public SpawnPointsFinder(int[,] map, Tilemap tilemap,
                              SpaceConfig spaceConfig,
                              StarSpawnConfig starSpawnConfig,
                              EnemySpawnConfig enemySpawnConfig)
        {
            //TODO REMADE ALL
            _map = map;
            _tilemap = tilemap;
            _starCount = spaceConfig.StarCount;

            if (spaceConfig.AutoRadius)
            {
                _starRadius = GetStarRadius(starSpawnConfig, tilemap);
            }
            else
            {
                _starRadius = spaceConfig.ManualRadius;
            }

            _enemyCount = enemySpawnConfig.EnemyGroupsSpawnPoints.Count;
            _enemyRadius = GetEnemyRadius(enemySpawnConfig, tilemap);

            _spaceObjectsMap = new int[_map.GetLength(0), _map.GetLength(1)];
        }

        public void Generate()
        {
            StarSpawnPoints(_spaceObjectsMap, _map, _starCount, _starRadius);
            PlayerSpawnPoint(_spaceObjectsMap);
            EnemiesSpawnPoints(_spaceObjectsMap, _enemyCount, _enemyRadius);
        }

        public List<Vector3> GetSpawnPoints(CellType cellType)
        {
            if (_spaceObjectsMap == null)
            {
                return new();
            }

            var spawnPoints = new List<Vector3>();

            for (int x = 0; x < _spaceObjectsMap.GetLength(0); x++)
            {
                for (int y = 0; y < _spaceObjectsMap.GetLength(1); y++)
                {
                    var positionTile = new Vector3Int(-_spaceObjectsMap.GetLength(0) / 2 + x,
                        -_spaceObjectsMap.GetLength(1) / 2 + y, 0);

                    if (_spaceObjectsMap[x, y] == (int)cellType)
                    {
                        spawnPoints.Add(_tilemap.GetCellCenterWorld(positionTile));
                    }
                }
            }

            return spawnPoints;
        }

        public Vector3 GetPlayerSpawnPoint()
        {
            if (_spaceObjectsMap == null)
            {
                return new();
            }

            for (int x = 0; x < _spaceObjectsMap.GetLength(0); x++)
            {
                for (int y = 0; y < _spaceObjectsMap.GetLength(1); y++)
                {
                    var positionTile = new Vector3Int(-_spaceObjectsMap.GetLength(0) / 2 + x,
                        -_spaceObjectsMap.GetLength(1) / 2 + y, 0);

                    if (_spaceObjectsMap[x, y] == (int)CellType.Player)
                    {
                        return _tilemap.GetCellCenterWorld(positionTile);
                    }
                }
            }

            Debug.LogWarning("Player: zero position!");
            return new();
        }

        private int GetStarRadius(StarSpawnConfig starSpawnConfig, Tilemap tilemap)
        {
            var maxStarSize = default(float);
            var maxOrbit = default(float);

            foreach (var item in starSpawnConfig.WeightConfigs)
            {
                maxStarSize = Mathf.Max(maxStarSize, item.Config.MaxSize);
                maxOrbit = Mathf.Max(maxOrbit, item.Config.MaxOrbit);
            }

            var radius = (maxStarSize / 2 + maxOrbit)
                / Mathf.Max(tilemap.cellSize.x * tilemap.transform.localScale.x,
                            tilemap.cellSize.y * tilemap.transform.localScale.y);
            Debug.Log($"Radius: {Mathf.CeilToInt(radius)}");

            return Mathf.CeilToInt(radius);
        }

        private int GetEnemyRadius(EnemySpawnConfig enemySpawnConfig, Tilemap tilemap)
        {
            var maxCount = default(int);

            foreach (var item in enemySpawnConfig.EnemyGroupsSpawnPoints)
            {
                maxCount = Mathf.Max(maxCount, item.GroupCount);
            }

            var radius = maxCount
                / Mathf.Max(tilemap.cellSize.x * tilemap.transform.localScale.x,
                            tilemap.cellSize.y * tilemap.transform.localScale.y);
            Debug.Log($"EnemyRadius: {Mathf.CeilToInt(radius)}");

            return Mathf.CeilToInt(radius);
        }

        private int MooreNeighborhoodCount(int[,] map, int gridX, int gridY, int radius, bool edgesAreWalls)
        {
            var neighbourCount = 0;

            for (int neighbourX = gridX - radius; neighbourX <= gridX + radius; neighbourX++)
            {
                for (int neighbourY = gridY - radius; neighbourY <= gridY + radius; neighbourY++)
                {
                    bool isInsideMap =
                        neighbourX >= 0 && neighbourX < map.GetLength(0)
                        && neighbourY >= 0 && neighbourY < map.GetLength(1);

                    if (isInsideMap)
                    {
                        if (neighbourX != gridX || neighbourY != gridY)
                        {
                            neighbourCount += map[neighbourX, neighbourY] > 0 ? 1 : 0;
                        }
                    }
                    else if (edgesAreWalls)
                    {
                        neighbourCount++;
                    }
                }
            }

            return neighbourCount;
        }

        private void StarSpawnPoints(int[,] spaceObjectsMap, int[,] map, int starCount, int radius)
        {
            if (spaceObjectsMap == null)
            {
                return;
            }

            if (map == null)
            {
                return;
            }

            var pseudoRandom = new Random();
            _availablePoints = CheckAvailablePoints(map, radius);
            TrySetCellOnMap(spaceObjectsMap, starCount, radius, pseudoRandom, CellType.Star);
        }

        private void PlayerSpawnPoint(int[,] spaceObjectsMap)
        {
            var pseudoRandom = new Random();
            TrySetCellOnMap(spaceObjectsMap, 1, 0, pseudoRandom, CellType.Player);
        }

        private void EnemiesSpawnPoints(int[,] spaceObjectsMap, int enemiesCount, int radius)
        {
            var pseudoRandom = new Random();
            TrySetCellOnMap(spaceObjectsMap, enemiesCount, radius, pseudoRandom, CellType.Enemy);
        }

        private void TrySetCellOnMap(int[,] map, int cellCount, int radius, Random pseudoRandom, CellType cellType)
        {
            if(_availablePoints == null)
            {
                return;
            }

            var count = 0;

            while (count < cellCount)
            {
                if (_availablePoints.Count == 0)
                {
                    Debug.LogWarning($"Not enough space for all \"{cellType}\" | Count = {count}");
                    break;
                }

                var i = pseudoRandom.Next(_availablePoints.Count);
                map[_availablePoints[i].X, _availablePoints[i].Y] = (int)cellType;
                RemovePoints(ref _availablePoints, _availablePoints[i].X, _availablePoints[i].Y, radius);
                count++;
            }
        }

        private List<Point> CheckAvailablePoints(int[,] map, int radius)
        {
            var points = new List<Point>();

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == (int)CellType.None)
                    {
                        if (MooreNeighborhoodCount(map, x, y, radius, true) == 0)
                        {
                            points.Add(new Point(x, y));
                        }
                    }
                }
            }

            return points;
        }

        private void RemovePoints(ref List<Point> points, int gridX, int gridY, int radius)
        {
            for (int neighbourX = gridX - radius; neighbourX <= gridX + radius; neighbourX++)
            {
                for (int neighbourY = gridY - radius; neighbourY <= gridY + radius; neighbourY++)
                {
                    var item = new Point(neighbourX, neighbourY);

                    if (points.Contains(item))
                    {
                        points.Remove(item);
                    }
                }
            }
        } 
    }
}