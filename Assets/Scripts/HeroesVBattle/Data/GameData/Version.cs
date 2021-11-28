using System;
using Sirenix.OdinInspector;

namespace HeroesVBattle.Data.GameData
{
  [Serializable]
  public struct Version
  {
    [HorizontalGroup]
    public int Main;
    [HorizontalGroup(LabelWidth = 1)]
    public int Additional;

    public override string ToString() => 
      Main + "." + Additional;
  }
}