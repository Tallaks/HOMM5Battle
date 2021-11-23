namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class AnimationState : IState
  {
    private readonly StateMachine _stateMachine;

    public AnimationState(StateMachine stateMachine) => 
      _stateMachine = stateMachine;

    public void Enter()
    {
    }

    public void Exit()
    {
    }
  }
}