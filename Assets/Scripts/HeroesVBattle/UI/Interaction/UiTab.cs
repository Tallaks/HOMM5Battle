using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.Interaction
{
  [RequireComponent(typeof(Image))]
  public class UiTab : UiButton
  {
    [SerializeField] private UiTabPanelList _allPanelList;
    [SerializeField] private UiTabPanel _panel;
    
    [SerializeField] private Sprite _activeState;
    [SerializeField] private Sprite _inactiveState;
    
    [ShowInInspector]
    private Sprite CurrentState
    {
      get => GetComponent<Image>().sprite;
      set => GetComponent<Image>().sprite = value;
    }
    
    protected override void Awake()
    {
      base.Awake();
      OnClick.AddListener(OpenTargetPanel);
    }

    private void OnDestroy() => 
      OnClick.RemoveAllListeners();

    public void SetCurrent() => 
      CurrentState = _activeState;

    public void UnsetCurrent() =>
      CurrentState = _inactiveState;

    private void OpenTargetPanel() => 
      _allPanelList.OpenTabPanel(_panel);
  }
}