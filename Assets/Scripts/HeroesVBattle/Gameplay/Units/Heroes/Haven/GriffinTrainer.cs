using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Gameplay.Units.Creatures;
using HeroesVBattle.Gameplay.Units.Creatures.Haven;

namespace HeroesVBattle.Gameplay.Units.Heroes.Haven
{
  public sealed class GriffinTrainer : Hero
  {
    public GriffinTrainer(HeroData heroData, Army army) : base(heroData, army)
    {
    }

    public override void UseSpecialization()
    {
      foreach (Unit unit in Army.Units)
      {
        if (unit.GetType() == typeof(ImperialGriffin))
        {
          int modificator = Level / 2;
          unit.Attack += modificator;
          unit.Defence += modificator;
        }
      }
    }
  }
}