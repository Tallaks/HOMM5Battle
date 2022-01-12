using UnityEngine;

namespace HeroesVBattle.Gameplay.GridMap.Extensions
{
  public static class CellsAlgebra
  {
    private const float YTilePosition = 0.01f;
    private const float SmallTilesCenterDistance = 2f;

    private static readonly Vector3 _zeroTilePosition = new Vector3(3,YTilePosition,4);
    
    public static Vector3 CellToWorld(this Vector2Int cellPos)
    {
      return new Vector3(
        _zeroTilePosition.x + SmallTilesCenterDistance * cellPos.x,
        _zeroTilePosition.y,
        _zeroTilePosition.z + SmallTilesCenterDistance * cellPos.y
        );
    }

    public static Vector2Int WorldToCell(this Vector3 worldPos)
    {
      return new Vector2Int(
        (int)((worldPos.x - _zeroTilePosition.x) / SmallTilesCenterDistance),
        (int)((worldPos.z - _zeroTilePosition.z) / SmallTilesCenterDistance)
        );
    }
  }
}