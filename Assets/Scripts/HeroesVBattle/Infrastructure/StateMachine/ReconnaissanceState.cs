using HeroesVBattle.Audio;
using HeroesVBattle.Infrastructure.UI;
using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class ReconnaissanceState : IState
  {
    private readonly StateMachine _stateMachine;
    private readonly UiFabric _uiFabric;
    private readonly SoundEffectsPlayer _soundEffectsPlayer;
    private ReconnaissanceStateMediator _uiMediator;

    public ReconnaissanceState(StateMachine stateMachine, UiFabric uiFabric, SoundEffectsPlayer soundEffectsPlayer)
    {
      _stateMachine = stateMachine;
      _uiFabric = uiFabric;
      _soundEffectsPlayer = soundEffectsPlayer;
    }

    public void Enter() => 
      _uiMediator = (ReconnaissanceStateMediator)_uiFabric.Create<ReconnaissanceState>();

    public void Exit()
    {
      _soundEffectsPlayer.PlayTransition();
      Object.Destroy(_uiMediator.gameObject);
    }
  }
}