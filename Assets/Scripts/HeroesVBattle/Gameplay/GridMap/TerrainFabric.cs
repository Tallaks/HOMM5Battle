using UnityEngine;
using Zenject;

namespace HeroesVBattle.Gameplay.GridMap
{
  public class TerrainFabric
  {
    private const string TerrainsPrefabsPath = "GridMap/Terrains";
    
    private readonly Vector3 _terrainPosition = new Vector3(-500, 0, -500);

    private readonly DiContainer _container;

    public TerrainFabric(DiContainer container) => 
      _container = container;

    public GameObject Create()
    {
      GameObject[] allTerrains = Resources.LoadAll<GameObject>(TerrainsPrefabsPath);
      int chosenIndex = Random.Range(0,allTerrains.Length);
      return _container.InstantiatePrefab(allTerrains[chosenIndex],_terrainPosition,Quaternion.identity, _container.InheritedDefaultParent);
    }
  }
}