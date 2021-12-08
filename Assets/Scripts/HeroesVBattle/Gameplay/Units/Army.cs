using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Gameplay.Units.Creatures;
using HeroesVBattle.Gameplay.Units.Heroes;
using UnityEngine;

namespace HeroesVBattle.Gameplay.Units
{
  public class Army
  {
    public Hero Hero { get; }
    public Unit[] Units { get; }

    public Army(ArmyData data, IHeroFabric heroFabric, ICreatureFabric creatureFabric)
    {
      Hero = heroFabric.Create(data.Hero,this);
      Units = new Unit[data.Squads.Length];

      var squadIndex = 0;
      foreach (UnitData squad in data.Squads)
      {
        Units[squadIndex] = creatureFabric.Create(squad);
        squadIndex++;
      }
      
      Hero.UseSpecialization();
    }
  }
}