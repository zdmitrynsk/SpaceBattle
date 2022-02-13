namespace CodeBase.Infrastructure.States
{
  public interface IPayloadedState<TPayload> : IExitableState
  {
    void Enter(TPayload payload);
  }

  public interface IPayloadedState<in TPayloadd, TPayload2> : IExitableState 
    where TPayloadd : class, IPayloadedState<TPayload2>
  {
    void Enter<TPayload>(TPayload2 payload) where TPayload : class, TPayloadd;
  }
}