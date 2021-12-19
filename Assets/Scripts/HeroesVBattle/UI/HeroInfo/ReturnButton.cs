using HeroesVBattle.Gameplay.Units;
using HeroesVBattle.Infrastructure.UI.Mediator;
using HeroesVBattle.UI.Interaction;
using UnityEngine;

namespace HeroesVBattle.UI.HeroInfo
{
  public class ReturnButton : MonoBehaviour
  {
    [SerializeField] 
    private UiButton _button;

    [SerializeField] 
    private HeroInfoMediator _mediator;

    private Army _army;

    private void Awake() => 
      _button.OnClick.AddListener(ReturnToGame);

    public void Init(Army army) => 
      _army = army;

    private void ReturnToGame()
    {
      if (_army.IsPlaced)
        _mediator.ReturnToBattle();
      else
        _mediator.ReturnToReconaissanse();
    }
  }
}