using HeroesVBattle.Data.EditorData;

namespace HeroesVBattle.Gameplay.Units.Heroes
{
  public interface IHeroFabric
  {
    Hero Create(HeroData data);
  }
}