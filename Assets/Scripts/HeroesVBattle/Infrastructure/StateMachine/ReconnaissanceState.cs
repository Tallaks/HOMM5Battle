using HeroesVBattle.Infrastructure.UI;
using HeroesVBattle.Infrastructure.UI.Mediator;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class ReconnaissanceState : IState
  {
    private readonly StateMachine _stateMachine;
    private readonly UiFabric _uiFabric;

    public ReconnaissanceState(StateMachine stateMachine, UiFabric uiFabric)
    {
      _stateMachine = stateMachine;
      _uiFabric = uiFabric;
    }

    public void Enter()
    {
      UiGameplayMediator uiMediator = _uiFabric.Create(this);
    }

    public void Exit()
    {
    }
  }
}