using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.Tactical
{
  public class TacticControlPanel : MonoBehaviour
  {
    [SerializeField] private Button _defenceButton;
    private TacticalStateMediator _mediator;

    private void Awake()
    {
      _defenceButton.onClick.AddListener(Defend);
      _mediator = GetComponent<TacticalStateMediator>();
    }

    private void Defend() => 
      _mediator.Defend();
  }
}