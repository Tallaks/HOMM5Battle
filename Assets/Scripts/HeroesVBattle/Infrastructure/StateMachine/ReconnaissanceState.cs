using HeroesVBattle.Audio;
using HeroesVBattle.Gameplay.GridMap;
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
    private readonly MapBuilder _mapBuilder;
    private ReconnaissanceStateMediator _uiMediator;
    private Army _army;

    public ReconnaissanceState(StateMachine stateMachine, UiFabric uiFabric, SoundEffectsPlayer soundEffectsPlayer,
      MapBuilder mapBuilder)
    {
      _stateMachine = stateMachine;
      _uiFabric = uiFabric;
      _soundEffectsPlayer = soundEffectsPlayer;
      _mapBuilder = mapBuilder;
    }

    public void Enter(Army army)
    {
      _army = army;
      CreateGridMap();
    }

    private void CreateGridMap()
    {
      _mapBuilder.OnBuild += InitUi;
      _mapBuilder.InitReconnaissanceGrid(_army).Build();
    }

    private void InitUi()
    {
      _uiMediator = (ReconnaissanceStateMediator)_uiFabric.Create<ReconnaissanceState>();
      _uiMediator.ConnectArmyToUI(_army);
    }

    public void Exit()
    {
      _mapBuilder.OnBuild -= InitUi;
      _soundEffectsPlayer.PlayTransition();
      Object.Destroy(_uiMediator.gameObject);
    }
  }
}