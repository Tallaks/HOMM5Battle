using HeroesVBattle.Data.GameData;
using UnityEngine;

namespace HeroesVBattle.Data.EditorData
{
  [CreateAssetMenu(fileName = "NewConfig", menuName = "Config", order = 0)]
  public class Config : ScriptableObject
  {
    public Version InitialDataVersion;
    public ArmyData Player;
    public ArmyData Enemy;
  }
}