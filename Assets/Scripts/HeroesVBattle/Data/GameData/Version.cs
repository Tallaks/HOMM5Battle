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

    public static bool operator ==(Version a, Version b) => 
      (a.Main == b.Main && a.Additional == b.Additional);

    public static bool operator !=(Version a, Version b) => 
      !(a == b);

    public static bool operator >(Version a, Version b)
    {
      if (a.Main > b.Main) return true;
      if (a.Main < b.Main) return false;
      if (a.Main == b.Main)
      {
        if (a.Additional > b.Additional) return true;
      }

      return false;
    }

    public static bool operator <(Version a, Version b) => 
      !(a > b);

    public override string ToString() => 
      Main + "." + Additional;
  }
}