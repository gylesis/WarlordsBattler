using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Warlords.Infrastructure.States
{
    public class StateMachine : IInitializable
    {
        private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
        private IState _activeState;

        public StateMachine(IState[] states)
        {
            foreach (IState state in states)
            {
                _states.Add(state.GetType(), state);
            }
        }

        public async void Initialize()
        {
            await Enter<BootstrapState>();
            await Enter<GameLoopState>();
        }

        public async UniTask Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            await state.Enter();
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