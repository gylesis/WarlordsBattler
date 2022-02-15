using System;
using System.Collections.Generic;
using UnityEngine;

namespace Warlords.Infrastracture.States
{
  public class StateMachine
  {
    private readonly Dictionary<Type, IState> _states;
    private IState _activeState;

    public StateMachine(IState[] states)
    {
      Debug.Log(states.Length);
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