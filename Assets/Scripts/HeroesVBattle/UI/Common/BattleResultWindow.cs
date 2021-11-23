using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.Common
{
  public class BattleResultWindow : MonoBehaviour
  {
    [SerializeField] private Button _exitButton;
    [SerializeField] private CommonMediator _mediator;
    
    private void Awake() => 
      _exitButton.onClick.AddListener(Exit);

    private void Exit() => 
      _mediator.Exit();

    public void Show() => 
      gameObject.SetActive(true);
  }
}