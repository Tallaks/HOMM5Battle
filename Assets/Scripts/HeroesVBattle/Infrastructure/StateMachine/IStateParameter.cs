namespace HeroesVBattle.Infrastructure.StateMachine
{
  public interface IStateParameter<TParameter> : IExitableState
  {
    void Enter(TParameter parameter);
  }
}