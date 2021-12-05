using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.Reconnaissance
{
  public class ReconnaissanceControlPanel : MonoBehaviour
  {
    [SerializeField] private Button _startBattleButton;

    private ReconnaissanceStateMediator _mediator;

    private void Awake()
    {
      _startBattleButton.onClick.AddListener(StartButton);
      _mediator = GetComponent<ReconnaissanceStateMediator>();
    }
    
    private void StartButton() => 
      _mediator.StartBattle();

    private void OnDestroy() => 
      _startBattleButton.onClick.RemoveAllListeners();
  }
}