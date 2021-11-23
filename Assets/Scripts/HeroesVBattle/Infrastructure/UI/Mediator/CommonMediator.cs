using HeroesVBattle.Infrastructure.StateMachine;
using HeroesVBattle.UI.Common;
using UnityEngine;
using Zenject;

namespace HeroesVBattle.Infrastructure.UI.Mediator
{
  public class CommonMediator : UiGameplayMediator
  {
    [SerializeField] private BattleResultWindow _battleResultWindow;
    
    [Inject]
    private StateMachine.StateMachine _stateMachine;

    public void OpenResultWindow() => _battleResultWindow.Show();
    public void Surrneder() => _stateMachine.Enter<BattleResultState>();
    public void Exit() => _stateMachine.Enter<ExitGameState>();
  }
}