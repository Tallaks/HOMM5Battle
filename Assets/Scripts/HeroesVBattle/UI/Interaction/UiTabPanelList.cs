using System.Collections.Generic;
using UnityEngine;

namespace HeroesVBattle.UI.Interaction
{
  public class UiTabPanelList : MonoBehaviour
  {
    [SerializeField] private List<UiTabPanel> _panels;

    private void Awake() => 
      OpenTabPanel(_panels[0]);

    public void OpenTabPanel(UiTabPanel panel)
    {
      foreach (UiTabPanel tabPanel in _panels)
      {
        if (panel == tabPanel) 
          tabPanel.Show();
        else
          tabPanel.Hide();
      }
    }
  }
}