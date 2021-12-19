using System;
using HeroesVBattle.Data.GameData;
using HeroesVBattle.Gameplay.Units;
using HeroesVBattle.Gameplay.Units.Creatures;
using HeroesVBattle.Gameplay.Units.Heroes;
using HeroesVBattle.Infrastructure.UI;
using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class LoadingLevelState : IState
  {
    private const string MainSceneName = "Main";
    private const string DisclaimerPrefabPath = "UI/Disclaimer";

    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly UiFabric _uiFabric;
    private readonly IHeroFabric _heroFabric;
    private readonly ICreatureFabric _creatureFabric;
    private readonly CommonMediator _commonMediator;
    private Disclaimer _disclaimer;
    private InitialData _initData;

    public LoadingLevelState(StateMachine stateMachine, SceneLoader sceneLoader, UiFabric uiFabric,
      IHeroFabric heroFabric, ICreatureFabric creatureFabric, CommonMediator commonMediator)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _uiFabric = uiFabric;
      _heroFabric = heroFabric;
      _creatureFabric = creatureFabric;
      _commonMediator = commonMediator;
    }

    public void Enter()
    {
      _commonMediator.Hide();
      InstantiateDisclaimer();
      LoadMainScene();
      LoadInitialData();
    }

    public void Exit() => 
      _commonMediator.Show();

    private void InstantiateDisclaimer()
    {
      var disclaimerPrefab = Resources.Load<GameObject>(DisclaimerPrefabPath);
      _disclaimer = Object.Instantiate(disclaimerPrefab).GetComponent<Disclaimer>();
    }

    private void LoadMainScene() => 
      _sceneLoader.Load(MainSceneName,OnLoadedScene);

    private void LoadInitialData()
    {
      var loader = new InitialDataLoader();
      if (!loader.LoadFromFile(out _initData))
        throw new Exception("Init Versions are not equal!");
    }

    private void OnLoadedScene()
    {
      HideDisclaimer();
      EnterNextState();
    }

    private void EnterNextState()
    {
      var army = new Army(_initData.PlayerArmy, _heroFabric, _creatureFabric);
      _stateMachine.EnterWithParameter<ReconnaissanceState, Army>(army);
    }

    private void HideDisclaimer()
    {
      _disclaimer.Hide();
      _disclaimer = null;
    }
  }
}