using System;
using System.Collections.Generic;
using HeroesVBattle.Audio;
using HeroesVBattle.Gameplay.Units.Creatures;
using HeroesVBattle.Gameplay.Units.Heroes;
using HeroesVBattle.Infrastructure.UI;
using HeroesVBattle.Infrastructure.UI.Mediator;
using Zenject;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class StateMachine : IStateMachine
  {
    private Dictionary<Type, IExitableState> _states;
    private IExitableState _currentState;

    public StateMachine(DiContainer diContainer)
    {
      _states = new Dictionary<Type, IExitableState>
      {
        [typeof(BootstrapState)] = new BootstrapState(this, diContainer),
        
        [typeof(LoadingLevelState)] = new LoadingLevelState(this, diContainer.Resolve<SceneLoader>(),
          diContainer.Resolve<UiFabric>(),
          diContainer.Resolve<IHeroFabric>(),
          diContainer.Resolve<ICreatureFabric>(),
          diContainer.Resolve<CommonMediator>()),
        
        [typeof(ReconnaissanceState)] = new ReconnaissanceState(this, diContainer.Resolve<UiFabric>(),
          diContainer.Resolve<SoundEffectsPlayer>()),
        
        [typeof(HeroInfoState)] = new HeroInfoState(this, diContainer.Resolve<UiFabric>(),
          diContainer.Resolve<SceneLoader>(),
          diContainer.Resolve<CommonMediator>()),
        
        [typeof(EnemyPlacingState)] = new EnemyPlacingState(this),
        [typeof(PlayerDefiningState)] = new PlayerDefiningState(this),
        [typeof(TacticalState)] = new TacticalState(this,diContainer.Resolve<UiFabric>()),
        [typeof(AnimationState)] = new AnimationState(this),
        [typeof(BattleResultState)] = new BattleResultState(this),
        [typeof(ExitGameState)] = new ExitGameState(this)
      };
    }

    public void Enter<TState>() where TState : class,IState
    {
      var state = ChangeState<TState>();
      state.Enter();
    }

    public void EnterWithParameter<TState, TParameter>(TParameter parameter) 
      where TState : class,IStateParameter<TParameter>
    {
      var state = ChangeState<TState>();
      state.Enter(parameter);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      _currentState?.Exit();
      _currentState = _states[typeof(TState)] as TState;

      return _states[typeof(TState)] as TState;
    }
  }
}