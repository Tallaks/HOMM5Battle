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

    private const float YTilePosition = 0.01f;
    private const float SmallTilesCenterDistance = 2f;
    
    private readonly Vector3 _firstTilePosition = new Vector3(3,YTilePosition,4);

    public ReconnaissanceTilesSpawner(DiContainer container) => 
      _container = container;

    public void Create(Army army)
    {
      for (var i = 0; i < MaxMapWidth; i++)
      {
        for (var j = 0; j < MaxMapHeightDefault; j++)
        {
          var currentTilePosition = new Vector3(
            i * SmallTilesCenterDistance + _firstTilePosition.x,
            YTilePosition,
            j * SmallTilesCenterDistance + _firstTilePosition.z);
          _container.InstantiatePrefabResource(TilePrefabPath, currentTilePosition, Quaternion.identity, _container.DefaultParent);
        }
      }
    }
  }
}