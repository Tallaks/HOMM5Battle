using UnityEngine;
using Zenject;

namespace HeroesVBattle.Infrastructure
{
  public class Bootstrapper : MonoBehaviour
  {
    private const string Main = "Main";
    
    [Inject]
    private SceneLoader _sceneLoader;
    
    private void Awake() => 
      LoadMainScene();

    private void LoadMainScene() => 
      _sceneLoader.Load(Main);
  }
}