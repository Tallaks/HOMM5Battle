using UnityEngine;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class ExitGameState : IState
  {
    public ExitGameState(StateMachine stateMachine)
    {
    }

    public void Enter()
    {
#if UNITY_EDITOR
      Debug.Break();
#endif
      Application.Quit();
    }

    public void Exit()
    {
    }
  }
}