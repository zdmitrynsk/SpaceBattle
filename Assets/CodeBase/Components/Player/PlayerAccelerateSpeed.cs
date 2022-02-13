using CodeBase.Infrastructure.Services.InputService;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Player
{
  [RequireComponent(typeof(Move.Move))]
  public class PlayerAccelerateSpeed : MonoBehaviour
  {
    [SerializeField] private Move.Move move;
    [SerializeField] private float accelerationValue = 9f;
    
    private IInputService _input;

    [Inject]
    public void Construct(IInputService input)
    {
      _input = input;
    }

    private void FixedUpdate()
    {
      if (IsPressedUp())
        Accelerate();
    }

    private bool IsPressedUp() => 
      InputAxisY() > 0;

    private float InputAxisY() => 
      _input.MoveVector.y;

    private void Accelerate() =>
      move.SpeedUp(FrameAcceleration());

    private Vector3 FrameAcceleration() => 
      gameObject.transform.up * accelerationValue * Time.fixedDeltaTime;
  }
}