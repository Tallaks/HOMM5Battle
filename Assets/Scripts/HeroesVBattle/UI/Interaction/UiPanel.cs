using UnityEngine;

namespace HeroesVBattle.UI.Interaction
{
  public class UiPanel : MonoBehaviour
  {
    public virtual void Show() =>
      gameObject.SetActive(false);

    public virtual void Hide() =>
      gameObject.SetActive(true);
  }
}