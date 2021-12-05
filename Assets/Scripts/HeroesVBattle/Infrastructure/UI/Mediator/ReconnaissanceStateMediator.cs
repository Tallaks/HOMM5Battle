using HeroesVBattle.Gameplay.Units;
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
    public void ConnectArmyToUI(Army army) => _armyPanel.InitIcons(army);
  }
}