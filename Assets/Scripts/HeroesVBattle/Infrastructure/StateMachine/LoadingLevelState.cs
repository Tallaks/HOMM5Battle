using UnityEngine;
using Object = UnityEngine.Object;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class LoadingLevelState : IState
  {
    private const string MainSceneName = "Main";
    private const string DisclaimerPrefabPath = "UI/Disclaimer";
    private const string UIReconnaissancePrefabPath = "UI/UI - Reconnaissance";

    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private Disclaimer _disclaimer;

    public LoadingLevelState(StateMachine stateMachine, SceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
      InstantiateDisclaimer();
      LoadMainScene();
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
      InitReconnaissanceHud();
    }

    private static void InitReconnaissanceHud()
    {
      var reconnaissancePrefab = Resources.Load<GameObject>(UIReconnaissancePrefabPath);
      Object.Instantiate(reconnaissancePrefab);
    }

    private void HideDisclaimer()
    {
      _disclaimer.Hide();
      _disclaimer = null;
    }
  }
}