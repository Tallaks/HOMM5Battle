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

    private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
    {
      yield return null;
      
      AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);
      while (!loadOperation.isDone)
        yield return null;

      onLoaded?.Invoke();
    }
  }
}