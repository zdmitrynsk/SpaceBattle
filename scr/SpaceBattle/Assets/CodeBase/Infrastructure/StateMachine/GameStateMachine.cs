using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.Logic;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine
{
  public class GameStateMachine : IGameStateMachine
  {
    private readonly Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    public GameStateMachine()
    {
      _states = new Dictionary<Type, IExitableState>();
    }

    public void Add(Type typeState, IExitableState state) => 
      _states[typeState] = state;

    public void Enter<TState>() where TState : class, IState
    {
      var state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayLoad>(TPayLoad payLoad) 
      where TState : class, IPayloadedState<TPayLoad>
    {
      TState state = ChangeState<TState>();
      state.Enter(payLoad);
    }

    public void Enter<TState, TSubstate, TPayload>(TPayload payload2)
      where TState : class, IPayloadedState<TSubstate, TPayload> 
      where TSubstate : class, IPayloadedState<TPayload>
    {
      TState state = ChangeState<TState>();
      state.Enter<TSubstate>(payload2);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      _activeState?.Exit();
      TState state = GetState<TState>();
      _activeState = state;
      return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState =>
      _states[typeof(TState)] as TState;
  }
}