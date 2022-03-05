using CodeBase.Infrastructure.Services;

namespace CodeBase.Infrastructure.States
{
  public interface IGameStateMachine : IService
  {
    void Enter<TState>() where TState : class, IState;
    void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayloadedState<TPayLoad>;

    void Enter<TState, TPayload, TPayload2>(TPayload2 payload2)
      where TState : class, IPayloadedState<TPayload, TPayload2>
      where TPayload : class, IPayloadedState<TPayload2>;
  }
}