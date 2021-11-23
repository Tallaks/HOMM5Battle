using HeroesVBattle.Infrastructure.StateMachine;
using Zenject;

namespace HeroesVBattle.Infrastructure.UI.Mediator
{
  public class CommonMediator : UiGameplayMediator
  {
    [Inject]
    private StateMachine.StateMachine _stateMachine;

    public void Surrneder() => _stateMachine.Enter<BattleResultState>();
  }
}