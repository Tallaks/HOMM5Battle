using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.Tactical
{
  public class TacticControlPanel : MonoBehaviour
  {
    [SerializeField] private Button _defenceButton;
    [SerializeField] private Button _surrenderButton;

    private TacticalStateMediator _mediator;

    private void Awake()
    {
      _defenceButton.onClick.AddListener(Defend);
      _surrenderButton.onClick.AddListener(Surrender);
      _mediator = GetComponent<TacticalStateMediator>();
    }

    private void Surrender() => 
      _mediator.Surrender();

    private void Defend() => 
      _mediator.Defend();

    private void OnDestroy()
    {
      _defenceButton.onClick.RemoveAllListeners();
      _surrenderButton.onClick.RemoveAllListeners();
    }
  }
}