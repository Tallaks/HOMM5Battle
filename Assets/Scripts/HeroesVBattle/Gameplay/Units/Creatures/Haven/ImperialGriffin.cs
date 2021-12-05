using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Gameplay.Units.Creatures.Abilities;

namespace HeroesVBattle.Gameplay.Units.Creatures.Haven
{
  public class ImperialGriffin : Unit, ILargeCreature, IUnlimitedRetaliation, IFlyer, IImmuneToBlind, IBattleDive
  {
    public ImperialGriffin(UnitData data) : base(data)
    {
    }

    public void SetPositionForLarge()
    {
    }

    public void Retaliate()
    {
    }

    public void FlyOver()
    {
    }

    public void IgnoreBlind()
    {
    }

    public void MakeDive()
    {
    }
  }
}