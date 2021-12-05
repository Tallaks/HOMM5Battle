using HeroesVBattle.Data.EditorData;
using UnityEngine;

namespace HeroesVBattle.Gameplay.Units.Heroes
{
  public abstract class Hero
  {
    public Sprite Icon { get; }

    protected readonly Faction Faction;

    public int Attack { get; }
    protected readonly int Defence;
    protected readonly int SpellPower;
    protected readonly int Knowledge;
    protected readonly int Luck;
    protected readonly int Morale;

    public Hero(HeroData heroData)
    {
      Attack = heroData.Attack;
      Defence = heroData.Defence;
      SpellPower = heroData.SpellPower;
      Knowledge = heroData.Knowledge;
      Luck = heroData.Luck;
      Morale = heroData.Morale;
      Faction = heroData.Faction;
      Icon = heroData.Icon;
    }
  }
}