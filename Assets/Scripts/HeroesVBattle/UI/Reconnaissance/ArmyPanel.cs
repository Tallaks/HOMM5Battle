using System;
using HeroesVBattle.Gameplay.Units;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.Reconnaissance
{
  public class ArmyPanel : MonoBehaviour
  {
    private const int ArmySize = 7;
    
    [SerializeField] private Image _heroIcon;
    [SerializeField] private SquadElement[] _unitElement = new SquadElement[ArmySize];

    public void InitIcons(Army army)
    {
      _heroIcon.sprite = army.Hero.Icon;
      
      for (var i = 0; i < Math.Min(ArmySize,army.Units.Length) ; i++) 
        _unitElement[i].InitElement(army.Units[i]);
    }
  }
}