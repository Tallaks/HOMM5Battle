using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace HeroesVBattle.Infrastructure
{
  public class SceneLoader
  {
    [Inject]
    private readonly ICoroutineRunner _coroutineRunner;
    
    public void Load(string sceneName, Action onLoaded = null) => 
      _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
    
    public void LoadAdditive(string sceneName, Action onLoaded = null) => 
      _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded, true));

    public void Unload(string sceneName) =>
      _coroutineRunner.StartCoroutine(UnloadScene(sceneName));

    private IEnumerator UnloadScene(string sceneName)
    {
      yield return null;

      AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(sceneName);
      while (!unloadOperation.isDone)
        yield return null;
    }

    private IEnumerator LoadScene(string sceneName, Action onLoaded = null, bool additive = false)
    {
      yield return null;
      
      AsyncOperation loadOperation =
        SceneManager.LoadSceneAsync(sceneName, additive == true ? LoadSceneMode.Additive : LoadSceneMode.Single);
      while (!loadOperation.isDone)
        yield return null;

      onLoaded?.Invoke();
    }
  }
}