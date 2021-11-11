using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.Infrastructure
{
  public class Disclaimer : MonoBehaviour
  {
    private const float FadeDuration = 0.5f;
    
    [SerializeField] private Image _background;
    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
      DontDestroyOnLoad(this);
    }

    public void Hide() => 
      FadeUI();

    private void FadeUI()
    {
      _background.DOFade(0, FadeDuration);
      _text.DOFade(0, FadeDuration).OnComplete(OnHidden);
    }

    private void OnHidden() => 
      Destroy(gameObject);
  }
}