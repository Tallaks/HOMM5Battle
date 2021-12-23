using HeroesVBattle.Gameplay.Units;
using UnityEngine;

namespace HeroesVBattle.UI.HeroInfo
{
  public class HeroInfoPanel : MonoBehaviour
  {
    [SerializeField] private ArmyAttributesTabPanel _armyAttributes;
    
    public void Init(Army army)
    {
      _armyAttributes.Init(army);
    }
  }
}