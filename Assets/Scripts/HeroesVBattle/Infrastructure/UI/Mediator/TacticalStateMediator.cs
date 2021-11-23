using HeroesVBattle.Infrastructure.StateMachine;
using Zenject;

namespace HeroesVBattle.Infrastructure.UI.Mediator
{
  public class TacticalStateMediator : UiGameplayMediator
  {
    [Inject]
    private StateMachine.StateMachine _stateMachine;

    public void Defend() => _stateMachine.Enter<PlayerDefiningState>();
  }
}