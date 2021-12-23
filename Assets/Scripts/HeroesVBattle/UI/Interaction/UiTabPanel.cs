using UnityEngine;

namespace HeroesVBattle.UI.Interaction
{
  public class UiTabPanel : UiPanel
  {
    [SerializeField] private UiTab _tab;
    [SerializeField] public string Title;
    
    public override void Show()
    {
      base.Show();
      _tab.SetCurrent();
    }

    public override void Hide()
    {
      base.Hide();
      _tab.UnsetCurrent();
    }
  }
}