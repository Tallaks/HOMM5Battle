using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HeroesVBattle.Data.EditorData
{
  [Serializable]
  public class Squad
  {
    private const int Size = 55;

    [PreviewField(Height = Size)]
    [TableColumnWidth(Size,false)]
    [ShowInInspector]
    [PropertyOrder(0)]
    public Texture Icon => Creature?.Icon;
    
    [PropertyOrder(1)]
    public CreatureData Creature;

    [PropertyOrder(2)]
    [TableColumnWidth(50,false)]
    public int Quantity;
  }
}