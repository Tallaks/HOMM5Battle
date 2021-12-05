using HeroesVBattle.Audio;
using HeroesVBattle.Gameplay.Units;
using HeroesVBattle.Infrastructure.UI;
using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class ReconnaissanceState : IStateParameter<Army>
  {
    private readonly StateMachine _stateMachine;
    private readonly UiFabric _uiFabric;
    private readonly SoundEffectsPlayer _soundEffectsPlayer;
    private ReconnaissanceStateMediator _uiMediator;
    private Army _army;

    public ReconnaissanceState(StateMachine stateMachine, UiFabric uiFabric, SoundEffectsPlayer soundEffectsPlayer)
    {
      _stateMachine = stateMachine;
      _uiFabric = uiFabric;
      _soundEffectsPlayer = soundEffectsPlayer;
    }

    public void Enter(Army army)
    {
      _army = army;
      _uiMediator = (ReconnaissanceStateMediator)_uiFabric.Create<ReconnaissanceState>();
      _uiMediator.ConnectArmyToUI(_army);
    }

    public void Exit()
    {
      _soundEffectsPlayer.PlayTransition();
      Object.Destroy(_uiMediator.gameObject);
    }
  }
}