using UnityEngine;

namespace HeroesVBattle.Gameplay.GridMap
{
  public interface IMap
  {
    EntityOnTile GetTileEntity(Vector2Int gridPosition);
  }
}