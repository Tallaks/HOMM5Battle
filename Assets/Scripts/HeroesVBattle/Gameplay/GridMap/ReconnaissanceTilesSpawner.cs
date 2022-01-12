using HeroesVBattle.Gameplay.GridMap.Extensions;
using HeroesVBattle.Gameplay.Units;
using UnityEngine;
using Zenject;

namespace HeroesVBattle.Gameplay.GridMap
{
  public class ReconnaissanceTilesSpawner
  {
    private readonly DiContainer _container;
    private const string TilePrefabPath = "GridMap/Tiles/ReconnaissanceTile";
    
    private const int MaxMapWidth = 10;
    private const int MaxMapHeightDefault = 2;

    public ReconnaissanceTilesSpawner(DiContainer container) => 
      _container = container;

    public void Create(Army army)
    {
      for (var i = 0; i < MaxMapWidth; i++)
      {
        for (var j = 0; j < MaxMapHeightDefault; j++)
        {
          Vector3 currentTilePosition = new Vector2Int(i, j).CellToWorld();
          _container.InstantiatePrefabResource(TilePrefabPath, currentTilePosition, Quaternion.identity, _container.DefaultParent);
        }
      }
    }
  }
}