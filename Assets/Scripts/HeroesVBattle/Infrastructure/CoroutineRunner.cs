using UnityEngine;

namespace HeroesVBattle.Infrastructure
{
  public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
  {
    private void Awake() => 
      DontDestroyOnLoad(this);
  }
}