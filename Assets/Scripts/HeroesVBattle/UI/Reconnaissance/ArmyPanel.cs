using HeroesVBattle.Gameplay.Units;
using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.Reconnaissance
{
  public class ArmyPanel : MonoBehaviour
  {
    [SerializeField] private Image _heroIcon;
    [SerializeField] private Image[] _creatureIcons = new Image[7];
    
    private ReconnaissanceStateMediator _mediator;

    private void Awake() => 
      _mediator = FindObjectOfType<ReconnaissanceStateMediator>();


    public void InitIcons(Army army) => 
      _heroIcon.sprite = army.Hero.Icon;
  }
}