using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Gameplay.Units.Heroes.Haven;
using HeroesVBattle.Gameplay.Units.Heroes.Inferno;

namespace HeroesVBattle.Gameplay.Units.Heroes
{
  public class HeroFabric : IHeroFabric
  {
    public Hero Create(HeroData data)
    {
      switch (data.Faction)
      {
        case Faction.Haven:
          return CreateHavenHero(data);
        case Faction.Inferno:
          return CreateInfernoHero(data);
        default:
          return null;
      }
    }

    private Hero CreateInfernoHero(HeroData data)
    {
      switch (data.HeroType)
      {
        case "Mindreaver":
          return new MindReaver(data);
        default:
          return null;
      }
    }

    private Hero CreateHavenHero(HeroData data)
    {
      switch (data.HeroType)
      {
        case "Griffin Trainer":
          return new GriffinTrainer(data);
        default:
          return null;
      }
    }
  }
}