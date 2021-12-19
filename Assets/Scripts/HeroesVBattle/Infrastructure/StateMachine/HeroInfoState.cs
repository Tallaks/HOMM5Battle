using HeroesVBattle.Gameplay.Units;
using HeroesVBattle.Infrastructure.UI;
using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class HeroInfoState : IStateParameter<Army>
  {
    private const string InfoSceneName = "Info";
    
    private readonly StateMachine _stateMachine;
    private readonly UiFabric _uiFabric;
    private readonly SceneLoader _sceneLoader;
    private readonly CommonMediator _commonMediator;

    private HeroInfoMediator _mediator;

    public HeroInfoState(StateMachine stateMachine, UiFabric uiFabric, SceneLoader sceneLoader, CommonMediator commonMediator)
    {
      _stateMachine = stateMachine;
      _uiFabric = uiFabric;
      _sceneLoader = sceneLoader;
      _commonMediator = commonMediator;
    }

    public void Enter(Army army)
    {
      _commonMediator.Hide();
      _sceneLoader.LoadAdditive(InfoSceneName);
      PrepareUiForState(army);
    }

    private void PrepareUiForState(Army army)
    {
      _mediator = (HeroInfoMediator)_uiFabric.Create<HeroInfoState>();
      _mediator.InitArmy(army);
      _mediator.InitInfoPanel();
      _mediator.InitBackButton();
    }

    public void Exit()
    {
      _commonMediator.Show();
      Object.Destroy(_mediator.gameObject);
      _sceneLoader.Unload(InfoSceneName);
    }
  }
}