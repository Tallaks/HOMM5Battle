using HeroesVBattle.Infrastructure.UI;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class TacticalState : IState
  {
    private readonly StateMachine _stateMachine;
    private readonly UiFabric _uiFabric;

    public TacticalState(StateMachine stateMachine, UiFabric uiFabric)
    {
      _stateMachine = stateMachine;
      _uiFabric = uiFabric;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }
  }
}