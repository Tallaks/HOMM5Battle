using UnityEngine;
using Zenject;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class BootstrapState : IState
  {
    private readonly StateMachine _stateMachine;
    private readonly DiContainer _diContainer;

    public BootstrapState(StateMachine stateMachine, DiContainer diContainer)
    {
      _stateMachine = stateMachine;
      _diContainer = diContainer;
      RegisterServices();
    }

    public void Enter() => 
      _stateMachine.Enter<LoadingLevelState>();

    private void RegisterServices()
    {
      _diContainer.Bind<IStateMachine>().To<StateMachine>().FromInstance(_stateMachine);
      _diContainer.Bind<CoroutineRunner>().FromMethod(Object.FindObjectOfType<CoroutineRunner>).AsSingle();
      _diContainer.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromResolve();
      _diContainer.Bind<SceneLoader>().FromNew().AsSingle();
      _diContainer.Bind<UiFabric>().FromNew().AsSingle();
    }

    public void Exit()
    {
    }
  }
}