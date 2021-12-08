using System;
using System.Collections.Generic;
using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Gameplay.Units.Creatures.Abilities;
using UnityEngine;

namespace HeroesVBattle.Gameplay.Units.Creatures
{
  public abstract class Unit
  {
    protected Dictionary<Type,IAbility> Abilities;
    public int Attack { get; set; }
    public int Defence { get; set; }

    public IEnumerable<KeyValuePair<Type,IAbility>> UnitAbilities => Abilities;
    public Sprite Icon { get; }
    public int Quantity { get; set; }

    public Unit(UnitData unitData)
    {
      Quantity = unitData.Quantity;
      Icon = unitData.Icon;

      Attack = unitData.Creature.Attack;
      Defence = unitData.Creature.Defence;
    }
  }
}