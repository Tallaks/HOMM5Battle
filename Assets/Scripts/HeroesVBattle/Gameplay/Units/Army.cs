using HeroesVBattle.Data.EditorData;

namespace HeroesVBattle.Gameplay.Units
{
  public class Army
  {
    private readonly Hero _hero;
    private readonly Unit[] _units;
    
    public Army(ArmyData data)
    {
      _hero = new Hero(data.Hero);
      
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