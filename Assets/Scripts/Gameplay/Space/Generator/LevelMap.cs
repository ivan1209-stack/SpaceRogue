using Scriptables.Space;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Space.Generator
{
    public sealed class LevelMap
    {
        private readonly Tilemap _borderTilemap;
        private readonly Tilemap _borderMaskTilemap;
        private readonly Tilemap _nebulaTilemap;
        private readonly Tilemap _nebulaMaskTilemap;

        private readonly TileBase _borderTileBase;
        private readonly TileBase _borderMaskTileBase;
        private readonly TileBase _nebulaTileBase;
        private readonly TileBase _nebulaMaskTileBase;

        private readonly int[,] _borderMap;
        private readonly int[,] _nebulaMap;

        public LevelMap(SpaceView spaceView, SpaceConfig spaceConfig, int[,] borderMap, int[,] nebulaMap)
        {
            _borderTilemap = spaceView.BorderTilemap;
            _borderMaskTilemap = spaceView.BorderMaskTilemap;
            _nebulaTilemap = spaceView.NebulaTilemap;
            _nebulaMaskTilemap = spaceView.NebulaMaskTilemap;

            _borderTileBase = spaceConfig.BorderTileBase;
            _borderMaskTileBase = spaceConfig.BorderMaskTileBase;
            _nebulaTileBase = spaceConfig.NebulaTileBase;
            _nebulaMaskTileBase = spaceConfig.NebulaMaskTileBase;

            _borderMap = borderMap;
            _nebulaMap = nebulaMap;
        }

        public void Draw()
        {
            DrawLayer(_borderMap, _borderTilemap, _borderTileBase, CellType.Border);
            DrawLayer(_borderMap, _borderMaskTilemap, _borderMaskTileBase, CellType.Border);
            DrawLayer(_nebulaMap, _nebulaTilemap, _nebulaTileBase, CellType.Obstacle);
            DrawLayer(_nebulaMap, _nebulaMaskTilemap, _nebulaMaskTileBase, CellType.Obstacle);
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