using HeroesVBattle.Gameplay.GridMap.Extensions;
using UnityEngine;

namespace HeroesVBattle.Gameplay.GridMap
{
  public class Map : IMap
  {
    private EntityOnTile[,] _grid = new EntityOnTile[CellsAlgebra.MaxMapWidth,CellsAlgebra.MaxMapLength];

    public Map()
    {
      for(var i = 0; i < _grid.GetUpperBound(0); i++)
      {
        for (var j = 0; j < _grid.GetUpperBound(1); j++)
        {
          _grid[i, j] = EntityOnTile.Empty;
        }
      }
    }

    public void WriteObstacleOnPosition(Vector2Int gridPosition) => 
      _grid[gridPosition.x, gridPosition.y] = EntityOnTile.Obstacle;

    public bool TileHasObstacle(Vector2Int gridPosition) => 
      _grid[gridPosition.x, gridPosition.y] == EntityOnTile.Obstacle;

    public EntityOnTile GetTileEntity(Vector2Int gridPosition) => 
      _grid[gridPosition.x, gridPosition.y];
  }
}