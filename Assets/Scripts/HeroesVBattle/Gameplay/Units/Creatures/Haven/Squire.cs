using System;
using System.Collections.Generic;
using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Gameplay.Units.Creatures.Abilities;

namespace HeroesVBattle.Gameplay.Units.Creatures.Haven
{
  public class Squire : Unit
  {
    public Squire(UnitData data) : base(data)
    {
      Abilities = new Dictionary<Type, IAbility>
      {
        [typeof(Bash)] = new Bash(),
        [typeof(Enraged)] = new Enraged(),
        [typeof(LargeShield)] = new LargeShield(),
        [typeof(ShieldAllies)] = new ShieldAllies()
      };
    }
  }
}