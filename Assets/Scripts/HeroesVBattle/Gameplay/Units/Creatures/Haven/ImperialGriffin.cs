using System;
using System.Collections.Generic;
using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Gameplay.Units.Creatures.Abilities;

namespace HeroesVBattle.Gameplay.Units.Creatures.Haven
{
  public class ImperialGriffin : Unit
  {
    public ImperialGriffin(UnitData data) : base(data)
    {
      Abilities = new Dictionary<Type, IAbility>()
      {
        [typeof(BattleDive)] = new BattleDive(),
        [typeof(Flyer)] = new Flyer(),
        [typeof(ImmuneToBlind)] = new ImmuneToBlind(),
        [typeof(LargeCreature)] = new LargeCreature(),
        [typeof(UnlimitedRetaliation)] = new UnlimitedRetaliation()
      };
    }
  }
}