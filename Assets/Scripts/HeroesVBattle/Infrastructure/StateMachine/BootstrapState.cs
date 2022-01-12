using System;
using HeroesVBattle.Audio;
using HeroesVBattle.Gameplay.GridMap.Builders;
using HeroesVBattle.Gameplay.Units.Creatures;
using HeroesVBattle.Gameplay.Units.Heroes;
using HeroesVBattle.Infrastructure.UI;
using HeroesVBattle.Infrastructure.UI.Mediator;
using Zenject;
using Object = UnityEngine.Object;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class BootstrapState : IState
  {
    private const string SoundEffectsPrefabPath = "Audio/Effects";
    private const string UICommonPrefabPath = "UI/UI - Common";
    
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
      _diContainer.Bind<StateMachine>().FromInstance(_stateMachine);
      _diContainer.Bind<CoroutineRunner>().FromMethod(Object.FindObjectOfType<CoroutineRunner>).AsSingle();
      _diContainer.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromResolve();
      _diContainer.Bind<SceneLoader>().FromNew().AsSingle();
      _diContainer.Bind<UiFabric>().FromNew().AsSingle().WithArguments(_diContainer);
      _diContainer.Bind<SoundEffectsPlayer>().FromMethod(InstantiateSoundEffectPlayer()).AsSingle();
      _diContainer.Bind<IHeroFabric>().To<HeroFabric>().FromNew().AsSingle();
      _diContainer.Bind<ICreatureFabric>().To<CreatureFabric>().FromNew().AsSingle();
      _diContainer.Bind<CommonMediator>().FromMethod(InstantiateCommonUi()).AsSingle();
      _diContainer.Bind<MapObjectsBuilder>().FromMethod((() => new MapObjectsBuilder(_diContainer))).AsSingle();
    }

    private Func<SoundEffectsPlayer> InstantiateSoundEffectPlayer() => 
      () => _diContainer.InstantiatePrefabResource(SoundEffectsPrefabPath).GetComponent<SoundEffectsPlayer>();

    private Func<CommonMediator> InstantiateCommonUi() => 
      () => _diContainer.InstantiatePrefabResource(UICommonPrefabPath).GetComponent<CommonMediator>();
    
    public void Exit()
    {
    }
  }
}