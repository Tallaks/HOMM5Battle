using HeroesVBattle.Infrastructure.StateMachine;
using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;
using Zenject;

namespace HeroesVBattle.Infrastructure.UI
{
  public class UiFabric
  {
    private readonly DiContainer _container;

    public UiFabric(DiContainer container) => 
      _container = container;

    private const string UIReconnaissancePrefabPath = "UI/UI - Reconnaissance";
    
    public UiGameplayMediator Create<TState>() where TState : IState
    {
      if (typeof(TState) == typeof(ReconnaissanceState))
        return InstantiateReconnaissanceHud();
      else return null;
    }

    private ReconnaissanceStateMediator InstantiateReconnaissanceHud() => 
      _container.InstantiatePrefabResource(UIReconnaissancePrefabPath).GetComponent<ReconnaissanceStateMediator>();
  }
}