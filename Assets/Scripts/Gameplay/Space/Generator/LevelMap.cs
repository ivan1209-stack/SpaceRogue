using Scriptables.Space;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Space.Generator
{
    public sealed class LevelMap
    {
        private readonly SpaceView _spaceView;
        private readonly SpaceConfig _spaceConfig;
        private readonly int[,] _borderMap;
        private readonly int[,] _nebulaMap;

        public LevelMap(SpaceView spaceView, SpaceConfig spaceConfig, int[,] borderMap, int[,] nebulaMap)
        {
            _spaceView = spaceView;
            _spaceConfig = spaceConfig;
            _borderMap = borderMap;
            _nebulaMap = nebulaMap;
        }

        public void Draw()
        {
            DrawLayer(_borderMap, _spaceView.BorderTilemap, _spaceConfig.BorderTileBase, CellType.Border);
            DrawLayer(_borderMap, _spaceView.BorderMaskTilemap, _spaceConfig.BorderMaskTileBase, CellType.Border);
            DrawLayer(_nebulaMap, _spaceView.NebulaTilemap, _spaceConfig.NebulaTileBase, CellType.Obstacle);
            DrawLayer(_nebulaMap, _spaceView.NebulaMaskTilemap, _spaceConfig.NebulaMaskTileBase, CellType.Obstacle);
        }

        private void DrawLayer(int[,] map, Tilemap tilemap, TileBase tileBase, CellType cellType)
        {
            if (map == null)
            {
                return;
            }

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    var positionTile = 
                        new Vector3Int(-map.GetLength(0) / 2 + x, -map.GetLength(1) / 2 + y, 0);

                    if (map[x, y] == (int)cellType)
                    {
                        tilemap.SetTile(positionTile, tileBase);
                    }
                }
            }
        }
    }
}