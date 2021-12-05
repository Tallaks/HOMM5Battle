using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Gameplay.Units.Creatures.Abilities;

namespace HeroesVBattle.Gameplay.Units.Creatures.Haven
{
  public class Squire : Unit, ILargeShield, IShieldAllies, IBash, IEnraged
  {
    public Squire(UnitData data) : base(data)
    {
    }

    public void ProtectFromShot()
    {
    }

    public void ProtectAllies()
    {
    }

    public void Bash()
    {
    }

    public void IncreaseAttack()
    {
    }
  }
}