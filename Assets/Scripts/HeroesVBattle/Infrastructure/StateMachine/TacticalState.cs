using HeroesVBattle.Infrastructure.UI;
using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class TacticalState : IState
  {
    private readonly StateMachine _stateMachine;
    private readonly UiFabric _uiFabric;
    private TacticalStateMediator _stateMediator;

    public TacticalState(StateMachine stateMachine, UiFabric uiFabric)
    {
      _stateMachine = stateMachine;
      _uiFabric = uiFabric;
    }

    public void Enter() => 
      _stateMediator = (TacticalStateMediator)_uiFabric.Create<TacticalState>();

    public void Exit() => 
      Object.Destroy(_stateMediator.gameObject);
  }
}