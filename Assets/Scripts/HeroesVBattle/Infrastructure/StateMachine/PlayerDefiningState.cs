namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class PlayerDefiningState : IState
  {
    private readonly StateMachine _stateMachine;

    public PlayerDefiningState(StateMachine stateMachine) => 
      _stateMachine = stateMachine;

    public void Enter() => 
      _stateMachine.Enter<TacticalState>();

    public void Exit()
    {
    }
  }
}