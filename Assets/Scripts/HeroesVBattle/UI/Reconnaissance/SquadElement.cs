using HeroesVBattle.Gameplay.Units.Creatures;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.Reconnaissance
{
  public class SquadElement : MonoBehaviour
  {
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _count;

    public void InitElement(Unit unit)
    {
      _icon.sprite = unit.Icon;
      _count.text = unit.Quantity.ToString();
    }
  }
}