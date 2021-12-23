using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HeroesVBattle.UI.Interaction
{
  public class UiTabPanelList : MonoBehaviour
  {
    [SerializeField] private TMP_Text _title;
    [SerializeField] private List<UiTabPanel> _panels;

    private void Awake() => 
      OpenTabPanel(_panels[0]);

    public void OpenTabPanel(UiTabPanel panel)
    {
      foreach (UiTabPanel tabPanel in _panels)
      {
        if (panel == tabPanel)
        {
          _title.text = tabPanel.Title;
          tabPanel.Show();
        }
        else
          tabPanel.Hide();
      }
    }
  }
}