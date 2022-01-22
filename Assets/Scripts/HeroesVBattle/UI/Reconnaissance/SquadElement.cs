using HeroesVBattle.Gameplay.Units.Creatures;
using HeroesVBattle.Infrastructure.UI.Mediator;
using HeroesVBattle.UI.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.Reconnaissance
{
  [RequireComponent(typeof(UiButton))]
  public class SquadElement : MonoBehaviour
  {
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _count;
    [SerializeField] private GameObject _selectionIndicator;
    private ReconnaissanceStateMediator _mediator;
    public Unit Unit { get; private set; }

    public void InitElement(Unit unit, ReconnaissanceStateMediator reconnaissanceStateMediator)
    {
      Unit = unit;
      _icon.sprite = unit.Icon;
      _count.text = unit.Quantity.ToString();
      _selectionIndicator.SetActive(false);
      _mediator = reconnaissanceStateMediator;
      
      GetComponent<UiButton>().OnClick.AddListener(OnClick);
    }

    private void OnClick() => 
      _mediator.ClickOnUnit(Unit);

    public void Select()
    {
      if(_selectionIndicator.activeInHierarchy)
        Deselect();
      else
        _selectionIndicator.SetActive(true);
    }

    public void Deselect() => 
      _selectionIndicator.SetActive(false);
  }
}