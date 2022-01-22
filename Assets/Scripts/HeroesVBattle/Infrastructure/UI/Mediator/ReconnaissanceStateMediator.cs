using HeroesVBattle.Gameplay.Units;
using HeroesVBattle.Gameplay.Units.Creatures;
using HeroesVBattle.Infrastructure.StateMachine;
using HeroesVBattle.UI.Reconnaissance;
using UnityEngine;
using Zenject;

namespace HeroesVBattle.Infrastructure.UI.Mediator
{
  public class ReconnaissanceStateMediator : UiGameplayMediator
  {
    [Inject]
    private StateMachine.StateMachine _stateMachine;

    [SerializeField] 
    private ArmyPanel _armyPanel;

    public void StartBattle() => _stateMachine.Enter<EnemyPlacingState>();
    public void ConnectArmyToUI(Army army) => _armyPanel.Init(army);
    public void OpenHeroInfo(Army armyOfHero) => _stateMachine.EnterWithParameter<HeroInfoState, Army>(armyOfHero);
    public void HideArmyPanel() => _armyPanel.Hide();
    public void ClickOnUnit(Unit unit) => _armyPanel.ClickOnUnitIcon(unit);
  }
}