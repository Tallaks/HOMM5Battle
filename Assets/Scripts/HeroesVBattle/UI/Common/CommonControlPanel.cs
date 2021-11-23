using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;
using UnityEngine.UI;

namespace HeroesVBattle.UI.Common
{
  public class CommonControlPanel : MonoBehaviour
  {
    [SerializeField] private Button _surrenderButton;
    
    private CommonMediator _mediator;
    
    private void Awake()
    {
      _surrenderButton.onClick.AddListener(Surrnder);
      _mediator = GetComponent<CommonMediator>();
    }

    private void Surrnder()
    {
      _mediator.OpenResultWindow();
      _mediator.Surrneder();
    }

    private void OnDestroy() => 
      _surrenderButton.onClick.RemoveAllListeners();
  }
}