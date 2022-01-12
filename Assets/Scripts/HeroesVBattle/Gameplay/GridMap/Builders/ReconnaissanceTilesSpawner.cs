using HeroesVBattle.Gameplay.GridMap.Extensions;
using HeroesVBattle.Gameplay.Units;
using UnityEngine;
using Zenject;

namespace HeroesVBattle.Gameplay.GridMap.Builders
{
  public class ReconnaissanceTilesSpawner
  {
    private readonly DiContainer _container;
    private const string TilePrefabPath = "GridMap/Tiles/ReconnaissanceTile";
    
    private const int MaxMapWidth = 10;
    private const int MaxMapHeightDefault = 2;

    public ReconnaissanceTilesSpawner(DiContainer container) => 
      _container = container;

    public void Create(Army army, Map map)
    {
      for (var i = 0; i < MaxMapWidth; i++)
      {
        for (var j = 0; j < MaxMapHeightDefault; j++)
        {
          var currentPositionCell = new Vector2Int(i, j);
          if(map.TileHasObstacle(currentPositionCell)) continue;

          Vector3 currentPositionWorld = currentPositionCell.CellToWorld();
          _container.InstantiatePrefabResource(TilePrefabPath, currentPositionWorld, Quaternion.identity, _container.DefaultParent);
        }
      }
    }
  }
}