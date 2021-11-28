namespace HeroesVBattle.Infrastructure.StateMachine
{
  public interface IState : IExitableState
  {
    void Enter();
  }
}