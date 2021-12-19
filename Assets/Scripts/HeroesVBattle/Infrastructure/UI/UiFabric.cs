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
    private const string UIHeroInfoPrefabPath = "UI/UI - HeroInfo";
    
    public UiGameplayMediator Create<TState>() where TState : IExitableState
    {
      if (typeof(TState) == typeof(ReconnaissanceState))
        return InstantiateReconnaissanceHud();
      if (typeof(TState) == typeof(TacticalState))
        return InstantiateTacticalHud();
      if (typeof(TState) == typeof(HeroInfoState))
        return InstantiateHeroInfoHud();
      else return null;
    }

    private TacticalStateMediator InstantiateTacticalHud() =>
    _container.InstantiatePrefabResource(UITacticPrefabPath).GetComponent<TacticalStateMediator>();

    private ReconnaissanceStateMediator InstantiateReconnaissanceHud() => 
      _container.InstantiatePrefabResource(UIReconnaissancePrefabPath).GetComponent<ReconnaissanceStateMediator>();

    private HeroInfoMediator InstantiateHeroInfoHud() =>
      _container.InstantiatePrefabResource(UIHeroInfoPrefabPath).GetComponent<HeroInfoMediator>();

  }
}