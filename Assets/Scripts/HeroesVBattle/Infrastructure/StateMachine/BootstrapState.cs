using UnityEngine;
using Zenject;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class BootstrapState : IState
  {
    private const string BootstrapperPath = "Infrastructure/Bootstrapper";

    private readonly StateMachine _stateMachine;
    private readonly DiContainer _diContainer;

    public BootstrapState(StateMachine stateMachine, DiContainer diContainer)
    {
      _stateMachine = stateMachine;
      _diContainer = diContainer;
    }

    public void Enter() => 
      RegisterServices();

    private void RegisterServices()
    {
      _diContainer.Bind<CoroutineRunner>().FromMethod(Object.FindObjectOfType<CoroutineRunner>).AsSingle();
      _diContainer.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromResolve();
      _diContainer.Bind<SceneLoader>().FromNew().AsSingle();
      var bootstrapper = _diContainer.InstantiatePrefabResourceForComponent<Bootstrapper>(BootstrapperPath);
      _diContainer.Bind<Bootstrapper>().FromInstance(bootstrapper).AsSingle();
    }

    public void Exit()
    {
    }
  }
}