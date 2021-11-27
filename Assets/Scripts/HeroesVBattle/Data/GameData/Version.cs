using System;

namespace HeroesVBattle.Data.GameData
{
  [Serializable]
  public struct Version
  {
    public int Main;
    public int Additional;
    public DateTime DateTime;

    public override string ToString() => 
      Main + "." + Additional;
  }
}