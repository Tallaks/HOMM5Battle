using HeroesVBattle.Data.EditorData;
using UnityEngine;

namespace HeroesVBattle.Gameplay.Units.Creatures
{
  public abstract class Unit
  {
    public Sprite Icon { get; }
    public int Quantity { get; set; }

    public Unit(UnitData unitData)
    {
      Quantity = unitData.Quantity;
      Icon = unitData.Icon;
    }
  }
}