using System;
using HeroesVBattle.Data.EditorData;

namespace HeroesVBattle.Data.GameData
{
  [Serializable]
  public class InitialData
  {
    public Version Version;
    public ArmyData PlayerArmy;
    public ArmyData EnemyArmy;
  }
}