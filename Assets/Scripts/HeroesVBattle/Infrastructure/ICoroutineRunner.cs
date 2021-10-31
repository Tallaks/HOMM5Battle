using System.Collections;
using UnityEngine;

namespace HeroesVBattle.Infrastructure
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator coroutine);
  }
}