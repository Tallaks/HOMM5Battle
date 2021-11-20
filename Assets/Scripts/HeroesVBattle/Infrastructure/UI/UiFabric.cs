using HeroesVBattle.Infrastructure.StateMachine;
using HeroesVBattle.Infrastructure.UI.Mediator;
using UnityEngine;

namespace HeroesVBattle.Infrastructure.UI
{
  public class UiFabric
  {
    private const string UIReconnaissancePrefabPath = "UI/UI - Reconnaissance";
    
    public UiGameplayMediator Create(IState gameState)
    {
      if (gameState.GetType() == typeof(ReconnaissanceState))
        return InstantiateReconnaissanceHud();
      else return null;
    }

    private UiGameplayMediator InstantiateReconnaissanceHud()
    {
      var reconnaissancePrefab = Resources.Load<GameObject>(UIReconnaissancePrefabPath);
      return Object.Instantiate(reconnaissancePrefab).GetComponent<ReconnaissanceStateMediator>();
    }
  }
}