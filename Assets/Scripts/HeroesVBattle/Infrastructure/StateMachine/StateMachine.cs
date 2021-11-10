using System;
using System.Collections.Generic;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class StateMachine
  {
    private Dictionary<Type, IState> _states;
    private IState _currentState;

    public StateMachine()
    {
      _states = new Dictionary<Type, IState>
      {

      };
    }

    public void Enter<TState>(TState state) where TState : IState
    {
      _currentState.Exit();
      _currentState = _states[typeof(TState)];
      _currentState.Enter();
    }
  }
}