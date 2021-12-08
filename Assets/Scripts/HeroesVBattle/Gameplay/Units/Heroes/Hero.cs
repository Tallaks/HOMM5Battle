using HeroesVBattle.Data.EditorData;
using UnityEngine;

namespace HeroesVBattle.Gameplay.Units.Heroes
{
  public abstract class Hero
  {
    public Sprite Icon { get; }

    protected readonly Faction Faction;
    protected readonly int Level;

    public int Attack { get; }
    protected readonly int Defence;
    protected readonly int SpellPower;
    protected readonly int Knowledge;
    protected readonly int Luck;
    protected readonly int Morale;
    
    protected readonly Army Army;
    
    public Hero(HeroData heroData, Army army)
    {
      Attack = heroData.Attack;
      Defence = heroData.Defence;
      SpellPower = heroData.SpellPower;
      Knowledge = heroData.Knowledge;
      Luck = heroData.Luck;
      Morale = heroData.Morale;
      Faction = heroData.Faction;
      Icon = heroData.Icon;
      Level = heroData.Level;
      
      Army = army;
    }

    public abstract void UseSpecialization();
  }
}