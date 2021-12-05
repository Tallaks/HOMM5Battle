using Sirenix.OdinInspector;
using UnityEngine;

namespace HeroesVBattle.Data.EditorData
{
  [CreateAssetMenu(menuName = "ObjectData/Hero", fileName = "NewHero", order = 0)]
  public class HeroData : SerializedScriptableObject
  {
    [PreviewField]
    public Sprite Icon;

    public Faction Faction;
    public string HeroType;
      
    public int Attack;
    public int Defence;
    public int SpellPower;
    public int Knowledge;
    public int Morale;
    public int Luck;
  }
}