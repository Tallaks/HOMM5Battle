using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.Reconnaissance
{
  public class ReconnaissanceControlPanel : MonoBehaviour
  {
    [SerializeField] private Button _startBattleButton;
    [SerializeField] private Button _surrenderButton;
    
    private ReconnaissanceStateMediator _mediator;

    private void Awake()
    {
      _startBattleButton.onClick.AddListener(StartButton);
      _surrenderButton.onClick.AddListener(Surrnder);
      _mediator = GetComponent<ReconnaissanceStateMediator>();
    }

    private void Surrnder() => 
      _mediator.Surrneder();

    private void StartButton() => 
      _mediator.StartBattle();

    private void OnDestroy()
    {
      _startBattleButton.onClick.RemoveAllListeners();
      _surrenderButton.onClick.RemoveAllListeners();
    }
  }
}