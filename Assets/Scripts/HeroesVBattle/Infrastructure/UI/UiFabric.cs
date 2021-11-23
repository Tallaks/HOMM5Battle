using HeroesVBattle.Infrastructure.StateMachine;
using HeroesVBattle.Infrastructure.UI.Mediator;
using Zenject;

namespace HeroesVBattle.Infrastructure.UI
{
  public class UiFabric
  {
    private readonly DiContainer _container;

    public UiFabric(DiContainer container) => 
      _container = container;

    private const string UIReconnaissancePrefabPath = "UI/UI - Reconnaissance";
    private const string UITacticPrefabPath = "UI/UI - TacticalState";
    private const string UICommonPrefabPath = "UI/UI - Common";

    public UiGameplayMediator Create<TState>() where TState : IState
    {
      if (typeof(TState) == typeof(ReconnaissanceState))
        return InstantiateReconnaissanceHud();
      if (typeof(TState) == typeof(TacticalState))
        return InstantiateTacticalHud();
      else return null;
    }

    public void CreateCommon() =>
      _container.InstantiatePrefabResource(UICommonPrefabPath);

    private TacticalStateMediator InstantiateTacticalHud() => 
      _container.InstantiatePrefabResource(UITacticPrefabPath).GetComponent<TacticalStateMediator>();

    private ReconnaissanceStateMediator InstantiateReconnaissanceHud() => 
      _container.InstantiatePrefabResource(UIReconnaissancePrefabPath).GetComponent<ReconnaissanceStateMediator>();
  }
}