using HeroesVBattle.Infrastructure.UI;
using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class ReconnaissanceState : IState
  {
    private readonly StateMachine _stateMachine;
    private readonly UiFabric _uiFabric;
    private ReconnaissanceStateMediator _uiMediator;

    public ReconnaissanceState(StateMachine stateMachine, UiFabric uiFabric)
    {
      _stateMachine = stateMachine;
      _uiFabric = uiFabric;
    }

    public void Enter()
    {
      _uiMediator = (ReconnaissanceStateMediator)_uiFabric.Create<ReconnaissanceState>();
    }

    public void Exit() => 
      Object.Destroy(_uiMediator.gameObject);
  }
}