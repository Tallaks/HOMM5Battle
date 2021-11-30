using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Gameplay.Units.Heroes;

namespace HeroesVBattle.Gameplay.Units
{
  public class Army
  {
    private readonly Hero _hero;
    private readonly Unit[] _units;
    
    public Army(ArmyData data, IHeroFabric heroFabric)
    {
      _hero = heroFabric.Create(data.Hero);
      _units = new Unit[7];

      var squadIndex = 0;
      foreach (UnitData squad in data.Squads)
      {
        _units[squadIndex] = new Unit(squad);
        squadIndex++;
      }
    }
  }
}