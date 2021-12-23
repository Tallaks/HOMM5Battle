using System;
using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Gameplay.Units;
using HeroesVBattle.UI.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.HeroInfo
{
  public class HeroBasicsPanel : UiPanel
  {
    [SerializeField] private Image _heroIcon;
    [SerializeField] private TMP_Text _heroNameTitle;
    [SerializeField] private TMP_Text _heroFactionField;
    [SerializeField] private TMP_Text _heroLevelField;

    public void Init(Army army)
    {
      _heroIcon.sprite = army.Hero.Icon;
      _heroNameTitle.text = army.Hero.Name;
      _heroFactionField.text = Enum.GetName(typeof(Faction), army.Hero.Faction);
      _heroLevelField.text = army.Hero.Level.ToString();
    }
  }
}