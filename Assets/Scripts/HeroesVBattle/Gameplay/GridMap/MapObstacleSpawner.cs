using System;
using System.Collections.Generic;
using HeroesVBattle.Gameplay.GridMap.Extensions;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace HeroesVBattle.Gameplay.GridMap
{
  public class MapObstacleSpawner
  {
    private readonly DiContainer _diContainer;
    private readonly Dictionary<GameObject, int> _obstacleList;
    private const string ObstaclesPrefabPath = "GridMap/Obstacles/";
    
    public MapObstacleSpawner(DiContainer diContainer, MapType mapType)
    {
      _diContainer = diContainer;
      
      GameObject[] obstacleTypes =
        Resources.LoadAll<GameObject>(ObstaclesPrefabPath + Enum.GetName(typeof(MapType), mapType));
      _obstacleList = InitObstacleList(obstacleTypes);
    }

    public void SpawnObstacles()
    {
      foreach (KeyValuePair<GameObject, int> pair in _obstacleList)
      {
        for (var i = 0; i < pair.Value; i++)
        {
          GameObject obstacle = _diContainer.InstantiatePrefab(pair.Key);
          PlaceObstacleOnMap(obstacle);
        }
      }
    }

    private static Dictionary<GameObject, int> InitObstacleList(GameObject[] obstacleTypes)
    {
      var obstacleList = new Dictionary<GameObject, int>(obstacleTypes.Length);
      foreach (GameObject prefabType in obstacleTypes) 
        obstacleList[prefabType] = Random.Range(0, 15);

      return obstacleList;
    }

    private void PlaceObstacleOnMap(GameObject obstacle) => 
      obstacle.transform.position = CellsAlgebra.RandomCell().CellToWorld();
  }
}