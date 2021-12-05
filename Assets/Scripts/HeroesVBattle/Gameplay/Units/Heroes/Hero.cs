using HeroesVBattle.Data.EditorData;
using UnityEngine;

namespace HeroesVBattle.Gameplay.Units.Heroes
{
  public abstract class Hero
  {
    protected readonly Texture Icon; 
    
    protected readonly Faction Faction;

    protected readonly int Attack;
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