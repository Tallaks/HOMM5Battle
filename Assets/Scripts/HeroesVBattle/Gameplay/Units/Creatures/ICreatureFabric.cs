using HeroesVBattle.Data.EditorData;

namespace HeroesVBattle.Gameplay.Units.Creatures
{
  public interface ICreatureFabric
  {
    Unit Create(UnitData data);
  }
}