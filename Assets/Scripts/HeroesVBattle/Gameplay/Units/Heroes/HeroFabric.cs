using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Gameplay.Units.Heroes.Haven;
using HeroesVBattle.Gameplay.Units.Heroes.Inferno;

namespace HeroesVBattle.Gameplay.Units.Heroes
{
  public class HeroFabric : IHeroFabric
  {
    public Hero Create(HeroData data, Army army)
    {
      switch (data.Faction)
      {
        case Faction.Haven:
          return CreateHavenHero(data, army);
        case Faction.Inferno:
          return CreateInfernoHero(data, army);
        default:
          return null;
      }
    }

    private Hero CreateInfernoHero(HeroData data, Army army)
    {
      switch (data.HeroType)
      {
        case "Mindreaver":
          return new MindReaver(data, army);
        default:
          return null;
      }
    }

    private Hero CreateHavenHero(HeroData data, Army army)
    {
      switch (data.HeroType)
      {
        case "Griffin Trainer":
          return new GriffinTrainer(data, army);
        default:
          return null;
      }
    }
  }
}