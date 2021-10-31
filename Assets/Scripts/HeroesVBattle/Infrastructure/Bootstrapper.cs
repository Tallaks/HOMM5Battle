using UnityEngine;

namespace HeroesVBattle.Infrastructure
{
  public class Bootstrapper : MonoBehaviour, ICoroutineRunner
  {
    private const string Main = "Main";
    private SceneLoader _sceneLoader;

    private void Awake()
    {
      LoadMainScene();
      DontDestroyOnLoad(this);
    }

    private void LoadMainScene()
    {
      _sceneLoader = new SceneLoader(this);
      _sceneLoader.Load(Main);
    }
  }
}