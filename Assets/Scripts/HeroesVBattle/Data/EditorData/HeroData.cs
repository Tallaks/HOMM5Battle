using Sirenix.OdinInspector;
using UnityEngine;

namespace HeroesVBattle.Data.EditorData
{
  [CreateAssetMenu(menuName = "ObjectData/Hero", fileName = "NewHero", order = 0)]
  public class HeroData : ScriptableObject
  {
    [PreviewField]
    public Texture Icon;
    
    public int Attack;
    public int Defence;
    public int SpellPower;
    public int Knowledge;
    public int Morale;
    public int Luck;
  }
}