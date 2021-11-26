using Sirenix.OdinInspector;
using UnityEngine;

namespace HeroesVBattle.Data.EditorData
{
  [CreateAssetMenu(menuName = "ObjectData/Creature", fileName = "NewCreature", order = 1)]
  public class CreatureData : ScriptableObject
  {
    [PreviewField]
    [TableColumnWidth(60,false)]
    public Texture Icon;
    
    public int Attack;
    public int Defence;
    public int MinDamage;
    public int MaxDamage;
    public int HitPoints;
    public int Speed;
    public int Initiative;
    public int Shots;
    public int Mana;
  }
}