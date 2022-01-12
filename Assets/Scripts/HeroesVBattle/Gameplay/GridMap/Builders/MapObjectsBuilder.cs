using System;
using HeroesVBattle.Gameplay.Units;
using UnityEngine;
using Zenject;

namespace HeroesVBattle.Gameplay.GridMap.Builders
{
  public class MapObjectsBuilder
  {
    private Map _map;
    private readonly DiContainer _container;
    private GameObject _terrain;

    public Action OnBuild { get; set; }

    public MapObjectsBuilder(DiContainer container)
    {
      _map = new Map();
      _container = container;
    }

    public MapObjectsBuilder InitTerrain()
    {
      _terrain = new TerrainFabric(_container).Create();
      return this;
    }

    public MapObjectsBuilder InitObstacles()
    {
      var obstacleSpawner = new MapObstacleSpawner(_container,GetMapType());
      obstacleSpawner.SpawnObstacles(_map);
      return this;
    }

    public Map Build()
    {
      OnBuild.Invoke();
      return _map;
    }

    public MapObjectsBuilder InitReconnaissanceGrid(Army army)
    {
      new ReconnaissanceTilesSpawner(_container).Create(army, _map);
      return this;
    }

    public MapObjectsBuilder InitBattleGrid() => this;

    private MapType GetMapType() => 
      _terrain.name.Contains("Grass") ? MapType.Grass : MapType.Rock;
  }
}