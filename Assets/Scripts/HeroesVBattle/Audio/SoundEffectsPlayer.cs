using UnityEngine;

namespace HeroesVBattle.Audio
{
  public class SoundEffectsPlayer : MonoBehaviour
  {
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _transitionSound;

    public void PlayTransition()
    {
      _source.clip = _transitionSound;
      _source.Play();
    }
  }
}