using System;
using HeroesVBattle.Gameplay.Units;
using HeroesVBattle.Infrastructure.UI.Mediator;
using HeroesVBattle.UI.Interaction;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.Reconnaissance
{
  public class ArmyPanel : MonoBehaviour
  {
    private const int ArmySize = 7;

    [Header("Mediator")] 
    [SerializeField] private ReconnaissanceStateMediator _mediator;

    [Header("Icons")]
    [SerializeField] private Image _heroIcon;
    [SerializeField] private SquadElement[] _unitElement = new SquadElement[ArmySize];

    [Space]
    [Header("Buttons")]
    [SerializeField] private UiButton _heroIconButton;

    public void Init(Army army)
    {
      InitIcons(army);
      InitButtons(army);
    }

    public void Hide() => 
      gameObject.SetActive(false);

    private void InitButtons(Army army) => 
      _heroIconButton.OnDoubleClick.AddListener(() => _mediator.OpenHeroInfo(army));

    private void InitIcons(Army army)
    {
      _heroIcon.sprite = army.Hero.Icon;
      
      for (var i = 0; i < Math.Min(ArmySize,army.Units.Length) ; i++) 
        _unitElement[i].InitElement(army.Units[i]);
    }
  }
}