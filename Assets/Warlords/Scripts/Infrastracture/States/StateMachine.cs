using System;
using System.Collections.Generic;

namespace Warlords.Infrastracture.States
{
  public class StateMachine
  {
    private Dictionary<Type, IState> _states;
    private IState _activeState;

    public StateMachine()
    {
      _states = new Dictionary<Type, IState>
      {
        /*[typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
        [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, loadingCurtain, services.Single<IGameFactory>(),
          services.Single<IPersistentProgressService>(), services.Single<IStaticDataService>(), services.Single<IUIFactory>()),
        
        [typeof(LoadProgressState)] = new LoadProgressState(this, services.Single<IPersistentProgressService>(), services.Single<ISaveLoadService>()),
        [typeof(GameLoopState)] = new GameLoopState(this),*/
      };
    }
    
    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }
    
    private TState ChangeState<TState>() where TState : class, IState
    {
      _activeState?.Exit();
      
      TState state = GetState<TState>();
      _activeState = state;
      
      return state;
    }

    private TState GetState<TState>() where TState : class, IState => 
      _states[typeof(TState)] as TState;
  }
}