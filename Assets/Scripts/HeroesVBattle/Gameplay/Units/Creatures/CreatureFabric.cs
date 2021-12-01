using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Gameplay.Units.Creatures.Haven;
using HeroesVBattle.Gameplay.Units.Creatures.Inferno;

namespace HeroesVBattle.Gameplay.Units.Creatures
{
  public class CreatureFabric : ICreatureFabric
  {
    public Unit Create(UnitData data)
    {
      switch (data.Creature.Faction)
      {
        case Faction.Haven:
          return CreateHavenUnit(data);
        case Faction.Inferno:
          return CreateInfernoUnit(data);
        default:
          return null;
      }
    }

    private Unit CreateInfernoUnit(UnitData data)
    {
      switch (data.Creature.name)
      {
        case "Pit Lord":
          return new PitLord(data);
        case "Horned Overseer":
          return new HornedOverseer(data);
        default:
          return null;
      }
    }

    private Unit CreateHavenUnit(UnitData data)
    {
      switch (data.Creature.name)
      {
        case "Imperial Griffin":
          return new ImperialGriffin(data);
        case "Squire":
          return new Squire(data);
        default:
          return null;
      }
    }
  }
}