using System.Collections.Generic;
using HeroesVBattle.Gameplay.Units;
using HeroesVBattle.UI.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.HeroInfo
{
  public class ArmyAttributesTabPanel : UiTabPanel
  {
    private const int MaxArmyCapacity = 7;
    
    [Space]
    [Header("Attributes")]
    [SerializeField] private TMP_Text _attackField;
    [SerializeField] private TMP_Text _defenceField;
    [SerializeField] private TMP_Text _spellPowerField;
    [SerializeField] private TMP_Text _knowledgeField;
    [SerializeField] private TMP_Text _moraleField;
    [SerializeField] private TMP_Text _luckField;
    
    [SerializeField] private TMP_Text _minManaField;
    [SerializeField] private TMP_Text _maxManaField;

    [Space]
    [Header("Army Icons")]
    [SerializeField] private List<Image> _armyIcons = new List<Image>(MaxArmyCapacity); 
    
    public void Init(Army army)
    {
      InitAttributes(army);
      InitArmy(army);
    }

    private void InitArmy(Army army)
    {
      for (int i = 0; i < army.Units.Length; i++)
      {
        _armyIcons[i].sprite = army.Units[i].Icon;
      }
    }

    private void InitAttributes(Army army)
    {
      _attackField.text = army.Hero.Attack.ToString();
      _defenceField.text = army.Hero.Defence.ToString();
      _spellPowerField.text = army.Hero.SpellPower.ToString();
      _knowledgeField.text = army.Hero.Knowledge.ToString();
      _moraleField.text = army.Hero.Morale.ToString();
      _luckField.text = army.Hero.Luck.ToString();
      _minManaField.text = army.Hero.MinMana.ToString();
      _maxManaField.text = army.Hero.MaxMana.ToString();
    }
  }
}