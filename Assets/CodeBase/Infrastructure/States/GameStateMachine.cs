﻿using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.States
{
  public class GameStateMachine : IGameStateMachine
  {
    private readonly Dictionary<Type,IExitableState> _states;
    private IExitableState _activeState;

    public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain, AllServices container)
    {
      _states = new Dictionary<Type, IExitableState>();
    }
    
    public void Enter<TState>() where TState : class, IState
    {
      var state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayloadedState<TPayLoad>
    {
      TState state = ChangeState<TState>();
      state.Enter(payLoad);
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