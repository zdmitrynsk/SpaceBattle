using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
  public interface IInputService
  {
    Vector2 MoveVector { get; }
    bool IsAttackButtonDown { get; }
  }
}