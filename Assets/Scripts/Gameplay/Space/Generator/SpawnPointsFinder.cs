using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

namespace Gameplay.Space.Generator
{
    public sealed class SpawnPointsFinder
    {
        private readonly int[,] _map;
        private readonly Tilemap _tilemap;
        private readonly int[,] _spaceObjectsMap;
        private readonly float _maxRealCellSize;

        private readonly List<Point> _availablePoints = new();

        public SpawnPointsFinder(int[,] map, Tilemap tilemap)
        {
            _map = map;
            _tilemap = tilemap;
            _spaceObjectsMap = new int[_map.GetLength(0), _map.GetLength(1)];

            _maxRealCellSize = Mathf.Max(
                _tilemap.cellSize.x * _tilemap.transform.localScale.x, 
                _tilemap.cellSize.y * _tilemap.transform.localScale.y);
            
            _availablePoints = GetEmptyPoints(map);
        }

        public Vector3 StarSpawnPoint(float starSize, float orbit)
        {
            var radius = CalculateStarRadius(starSize, orbit);
            FindAvailablePointOnMap(_availablePoints, CellType.Star, _spaceObjectsMap, 1, radius);
            return GetSpawnPoint(CellType.Star);
        }
        
        public Vector3 GetPlayerSpawnPoint()
        {
            FindAvailablePointOnMap(_availablePoints, CellType.Player, _spaceObjectsMap, 1, 1);
            return GetSpawnPoint(CellType.Player);
        }

        public Vector3 EnemySpawnPoint(int groupCount)
        {
            var radius = CalculateEnemyRadius(groupCount);
            FindAvailablePointOnMap(_availablePoints, CellType.Enemy, _spaceObjectsMap, 1, radius);
            return GetSpawnPoint(CellType.Enemy);
        }

        private List<Point> GetEmptyPoints(int[,] map)
        {
            var points = new List<Point>();

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == (int)CellType.None)
                    {
                        points.Add(new Point(x, y));
                    }
                }
            }

            return points;
        }

        private int CalculateStarRadius(float starSize, float orbit)
        {
            var radius = (starSize / 2 + orbit) / _maxRealCellSize;
            Debug.Log($"StarRadius: {Mathf.CeilToInt(radius)}");
            return Mathf.CeilToInt(radius);
        }

        private int CalculateEnemyRadius(int groupCount)
        {
            var radius = groupCount / _maxRealCellSize;
            Debug.Log($"EnemyRadius: {Mathf.CeilToInt(radius)}");
            return Mathf.CeilToInt(radius);
        }

        private void FindAvailablePointOnMap(List<Point> points, CellType cellType, int[,] map, int cellCount, int radius)
        {
            var count = 0;
            var pseudoRandom = new Random();

            while (count < cellCount)
            {
                if (points.Count == 0)
                {
                    Debug.LogWarning($"Not enough space for all \"{cellType}\" | Count = {count}");
                    break;
                }

                var i = pseudoRandom.Next(points.Count);

                if (СheckNeighborsInRadius(points, points[i].X, points[i].Y, radius))
                {
                    continue;
                }

                map[points[i].X, points[i].Y] = (int)cellType;
                RemovePoints(points, points[i].X, points[i].Y, radius);
                count++;
            }
        }

        private bool СheckNeighborsInRadius(List<Point> points, int gridX, int gridY, int radius)
        {
            var squareRadius = radius * radius;
            for (int neighbourX = gridX - radius; neighbourX <= gridX + radius; neighbourX++)
            {
                for (int neighbourY = gridY - radius; neighbourY <= gridY + radius; neighbourY++)
                {
                    var circleX = neighbourX - gridX;
                    var circleY = neighbourY - gridY;
                    var value = circleX * circleX + circleY * circleY;

                    if (value <= squareRadius)
                    {
                        if (!points.Contains(new(neighbourX, neighbourY)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void RemovePoints(List<Point> points, int gridX, int gridY, int radius)
        {
            var squareRadius = radius * radius;
            for (int neighbourX = gridX - radius; neighbourX <= gridX + radius; neighbourX++)
            {
                for (int neighbourY = gridY - radius; neighbourY <= gridY + radius; neighbourY++)
                {
                    var circleX = neighbourX - gridX;
                    var circleY = neighbourY - gridY;
                    var value = circleX * circleX + circleY * circleY;

                    if (value <= squareRadius)
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

        private Vector3 GetSpawnPoint(CellType cellType)
        {
            var startX = -_spaceObjectsMap.GetLength(0) / 2;
            var startY = -_spaceObjectsMap.GetLength(1) / 2;

            for (int x = 0; x < _spaceObjectsMap.GetLength(0); x++)
            {
                for (int y = 0; y < _spaceObjectsMap.GetLength(1); y++)
                {
                    if (_spaceObjectsMap[x, y] == (int)cellType)
                    {
                        var positionTile = new Vector3Int(startX + x, startY + y, 0);
                        _spaceObjectsMap[x, y] = (int)CellType.Spawned;
                        return _tilemap.GetCellCenterWorld(positionTile);
                    }
                }
            }

            Debug.LogWarning("Zero position");
            return new();
        }
    }
}