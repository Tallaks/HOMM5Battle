using HeroesVBattle.Audio;
using HeroesVBattle.Gameplay.GridMap;
using HeroesVBattle.Gameplay.GridMap.Builders;
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
    private readonly MapObjectsBuilder _mapObjectsBuilder;
    private ReconnaissanceStateMediator _uiMediator;
    private Army _army;

    public ReconnaissanceState(StateMachine stateMachine, UiFabric uiFabric, SoundEffectsPlayer soundEffectsPlayer,
      MapObjectsBuilder mapObjectsBuilder)
    {
      _stateMachine = stateMachine;
      _uiFabric = uiFabric;
      _soundEffectsPlayer = soundEffectsPlayer;
      _mapObjectsBuilder = mapObjectsBuilder;
    }

    public void Enter(Army army)
    {
      _army = army;
      CreateGridMap();
    }

    private void CreateGridMap()
    {
      _mapObjectsBuilder.OnBuild += InitUi;
      _mapObjectsBuilder.InitReconnaissanceGrid(_army).Build();
    }

    private void InitUi()
    {
      _uiMediator = (ReconnaissanceStateMediator)_uiFabric.Create<ReconnaissanceState>();
      _uiMediator.ConnectArmyToUI(_army);
    }

    public void Exit()
    {
      _mapObjectsBuilder.OnBuild -= InitUi;
      _soundEffectsPlayer.PlayTransition();
      Object.Destroy(_uiMediator.gameObject);
    }
  }
}