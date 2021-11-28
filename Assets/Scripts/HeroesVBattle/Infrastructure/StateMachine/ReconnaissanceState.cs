using HeroesVBattle.Audio;
using HeroesVBattle.Data.GameData;
using HeroesVBattle.Infrastructure.UI;
using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class ReconnaissanceState : IStateParameter<InitialData>
  {
    private readonly StateMachine _stateMachine;
    private readonly UiFabric _uiFabric;
    private readonly SoundEffectsPlayer _soundEffectsPlayer;
    private ReconnaissanceStateMediator _uiMediator;
    private InitialData _initData;

    public ReconnaissanceState(StateMachine stateMachine, UiFabric uiFabric, SoundEffectsPlayer soundEffectsPlayer)
    {
      _stateMachine = stateMachine;
      _uiFabric = uiFabric;
      _soundEffectsPlayer = soundEffectsPlayer;
    }

    public void Enter(InitialData data)
    {
      _uiMediator = (ReconnaissanceStateMediator)_uiFabric.Create<ReconnaissanceState>();
      _initData = data;
    }

    public void Exit()
    {
      _soundEffectsPlayer.PlayTransition();
      Object.Destroy(_uiMediator.gameObject);
    }
  }
}