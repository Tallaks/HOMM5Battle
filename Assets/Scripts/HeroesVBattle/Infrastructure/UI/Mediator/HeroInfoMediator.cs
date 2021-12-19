using HeroesVBattle.Gameplay.Units;
using HeroesVBattle.Infrastructure.StateMachine;
using HeroesVBattle.UI.HeroInfo;
using UnityEngine;
using Zenject;

namespace HeroesVBattle.Infrastructure.UI.Mediator
{
  public class HeroInfoMediator : UiGameplayMediator
  {
    [Inject]
    private StateMachine.StateMachine _stateMachine;

    [SerializeField] 
    private HeroInfoPanel _infoPanel;

    [SerializeField] 
    private ReturnButton _returnButton;

    private Army _army;

    public void InitArmy(Army army) => _army = army;
    public void InitInfoPanel() => _infoPanel.Init(_army);
    public void InitBackButton() => _returnButton.Init(_army);
    public void ReturnToReconaissanse() => _stateMachine.EnterWithParameter<ReconnaissanceState, Army>(_army);
    public void ReturnToBattle() => _stateMachine.EnterWithParameter<TacticalState, Army>(_army);
  }
}