namespace CodeBase.Infrastructure.StateMachine
{
  public interface IPayloadedState<TPayload> : IExitableState
  {
    void Enter(TPayload payload);
  }

  public interface IPayloadedState<in TPayloadState, TPayload2> : IExitableState 
    where TPayloadState : class, IPayloadedState<TPayload2>
  {
    void Enter<TPayloadMethod>(TPayload2 payload) where TPayloadMethod : class, TPayloadState;
  }
}