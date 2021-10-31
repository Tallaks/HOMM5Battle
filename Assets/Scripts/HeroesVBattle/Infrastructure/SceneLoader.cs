using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeroesVBattle.Infrastructure
{
  public class SceneLoader
  {
    private readonly ICoroutineRunner _coroutineRunner;

    public SceneLoader(ICoroutineRunner coroutineRunner)
    {
      _coroutineRunner = coroutineRunner;
    }

    public void Load(string sceneName, Action onLoaded = null)
    {
      _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
    }

    private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
    {
      AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName);
      while (!loadOperation.isDone)
      {
        yield return null;
      }
      
      onLoaded?.Invoke();
    }
  }
}