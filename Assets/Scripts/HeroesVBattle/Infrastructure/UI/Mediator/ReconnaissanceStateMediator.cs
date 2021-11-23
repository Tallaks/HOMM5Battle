using HeroesVBattle.Infrastructure.StateMachine;
using Zenject;

namespace HeroesVBattle.Infrastructure.UI.Mediator
{
  public class ReconnaissanceStateMediator : UiGameplayMediator
  {
    [Inject]
    private StateMachine.StateMachine _stateMachine;

    public void StartBattle() => _stateMachine.Enter<EnemyPlacingState>();
  }
}