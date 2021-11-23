namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class EnemyPlacingState : IState
  {
    private readonly StateMachine _stateMachine;

    public EnemyPlacingState(StateMachine stateMachine) => 
      _stateMachine = stateMachine;

    public void Enter() => 
      _stateMachine.Enter<PlayerDefiningState>();

    public void Exit()
    {
    }
  }
}