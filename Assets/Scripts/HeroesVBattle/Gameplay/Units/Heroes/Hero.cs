using HeroesVBattle.Data.EditorData;
using UnityEngine;

namespace HeroesVBattle.Gameplay.Units.Heroes
{
  public abstract class Hero
  {
    public string Name { get; }
    public Sprite Icon { get; }
    public Faction Faction { get; } 
    public int Level { get; }

    public int Attack { get; }
    public int Defence { get; }
    public int SpellPower { get; }
    public int Knowledge { get; }
    public int Luck { get; }
    public int Morale { get; }

    public int MinMana { get; set; }
    public int MaxMana => Knowledge * 10;

    protected readonly Army Army;
    
    public Hero(HeroData heroData, Army army)
    {
      Name = heroData.name;
      Attack = heroData.Attack;
      Defence = heroData.Defence;
      SpellPower = heroData.SpellPower;
      Knowledge = heroData.Knowledge;
      Luck = heroData.Luck;
      Morale = heroData.Morale;
      Faction = heroData.Faction;
      Icon = heroData.Icon;
      Level = heroData.Level;

      MinMana = MaxMana;
      Army = army;
    }

    public abstract void UseSpecialization();
  }
}