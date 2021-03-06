using System;
using System.Collections.Generic;
using HeroesVBattle.Audio;
using HeroesVBattle.Infrastructure.UI;
using Zenject;

namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class StateMachine : IStateMachine
  {
    private Dictionary<Type, IState> _states;
    private IState _currentState;

    public StateMachine(DiContainer diContainer)
    {
      _states = new Dictionary<Type, IState>
      {
        [typeof(BootstrapState)] = new BootstrapState(this, diContainer),
        [typeof(LoadingLevelState)] = new LoadingLevelState(this, diContainer.Resolve<SceneLoader>(), diContainer.Resolve<UiFabric>()),
        [typeof(ReconnaissanceState)] = new ReconnaissanceState(this, diContainer.Resolve<UiFabric>(),diContainer.Resolve<SoundEffectsPlayer>()),
        [typeof(EnemyPlacingState)] = new EnemyPlacingState(this),
        [typeof(PlayerDefiningState)] = new PlayerDefiningState(this),
        [typeof(TacticalState)] = new TacticalState(this,diContainer.Resolve<UiFabric>()),
        [typeof(AnimationState)] = new AnimationState(this),
        [typeof(BattleResultState)] = new BattleResultState(this),
        [typeof(ExitGameState)] = new ExitGameState(this)
      };
    }

    public void Enter<TState>() where TState : IState
    {
      _currentState?.Exit();
      _currentState = _states[typeof(TState)];
      _currentState.Enter();
    }
  }
}