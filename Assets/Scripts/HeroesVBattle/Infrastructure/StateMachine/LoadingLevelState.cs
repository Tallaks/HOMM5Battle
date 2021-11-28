using HeroesVBattle.Data.GameData;
using HeroesVBattle.Infrastructure.UI;
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
    private Disclaimer _disclaimer;
    private InitialData _initData;

    public LoadingLevelState(StateMachine stateMachine, SceneLoader sceneLoader, UiFabric uiFabric)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _uiFabric = uiFabric;
    }

    public void Enter()
    {
      InstantiateDisclaimer();
      LoadMainScene();

      var loader = new InitialDataLoader();
      _initData = loader.LoadFromFile();
    }

    public void Exit()
    {
    }

    private void InstantiateDisclaimer()
    {
      var disclaimerPrefab = Resources.Load<GameObject>(DisclaimerPrefabPath);
      _disclaimer = Object.Instantiate(disclaimerPrefab).GetComponent<Disclaimer>();
    }

    private void LoadMainScene() => 
      _sceneLoader.Load(MainSceneName,OnLoadedScene);

    private void OnLoadedScene()
    {
      HideDisclaimer();
      _uiFabric.CreateCommon();
      _stateMachine.EnterWithParameter<ReconnaissanceState, InitialData>(_initData);
    }

    private void HideDisclaimer()
    {
      _disclaimer.Hide();
      _disclaimer = null;
    }
  }
}