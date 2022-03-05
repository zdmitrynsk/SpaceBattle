using UnityEngine;

namespace CodeBase.Infrastructure.Services.InputService
{
  public interface IInputService
  {
    Vector2 MoveVector { get; }
    bool IsAttackButtonDown { get; }
  }
}