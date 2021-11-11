using UnityEngine;

namespace HeroesVBattle.Infrastructure
{
  public class Disclaimer : MonoBehaviour
  {
    private void Awake() => 
      DontDestroyOnLoad(this);

    public void Hide() => 
      Destroy(gameObject);
  }
}