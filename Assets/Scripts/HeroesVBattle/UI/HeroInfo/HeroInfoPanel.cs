using HeroesVBattle.Gameplay.Units;
using UnityEngine;

namespace HeroesVBattle.UI.HeroInfo
{
  public class HeroInfoPanel : MonoBehaviour
  {
    [SerializeField] private HeroBasicsPanel _heroPanel;
    [SerializeField] private ArmyAttributesTabPanel _armyAttributes;
    
    public void Init(Army army)
    {
      _heroPanel.Init(army);
      _armyAttributes.Init(army);
    }
  }
}