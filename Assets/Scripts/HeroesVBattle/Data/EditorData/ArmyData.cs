using Sirenix.OdinInspector;
using UnityEngine;

namespace HeroesVBattle.Data.EditorData
{
  [CreateAssetMenu(menuName = "ObjectData/Army", fileName = "NewArmy", order = 5)]
  public class ArmyData : SerializedScriptableObject
  {
    [HorizontalGroup("Hero")]
    
    [BoxGroup("Hero/Icon",order: 0)]
    [ShowInInspector]
    [PreviewField(Height = 55,Alignment = ObjectFieldAlignment.Left)]
    public Texture Icon => Hero.Icon;
    
    [BoxGroup("Hero/Hero",order: 1)]
    [PreviewField(Height = 55)]
    public HeroData Hero;

    [BoxGroup("Army")]
    [TableList]
    public Squad[] Squads;
  }
}