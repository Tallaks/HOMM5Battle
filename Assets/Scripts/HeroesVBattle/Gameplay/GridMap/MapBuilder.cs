using System;
using HeroesVBattle.Gameplay.Units;
using UnityEngine;
using Zenject;

namespace HeroesVBattle.Gameplay.GridMap
{
  public class MapBuilder
  {
    private readonly DiContainer _container;
    private GameObject _terrain;

    public Action OnBuild { get; set; }

    public MapBuilder(DiContainer container) => 
      _container = container;

    public MapBuilder InitTerrain()
    {
      _terrain = new TerrainFabric(_container).Create();
      return this;
    }

    public MapBuilder InitObstacles() => this;


    public MapBuilder InitReconnaissanceGrid(Army army)
    {
      new ReconnaissanceTilesSpawner(_container).Create(army);
      return this;
    }

    public MapBuilder InitBattleGrid() => this;

    public void Build() => OnBuild.Invoke();
  }
}