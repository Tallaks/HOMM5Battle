using System;
using System.Collections.Generic;
using Zenject;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class StateMachine
  {
    private Dictionary<Type, IState> _states;
    private IState _currentState;

    public StateMachine(DiContainer diContainer)
    {
      _states = new Dictionary<Type, IState>
      {
        [typeof(BootstrapState)] = new BootstrapState(this, diContainer)
      };
    }

    public void Enter<TState>() where TState : IState
    {
      _currentState?.Exit();
      _currentState = _states[typeof(TState)];
      _currentState.Enter();
    }
  }
}