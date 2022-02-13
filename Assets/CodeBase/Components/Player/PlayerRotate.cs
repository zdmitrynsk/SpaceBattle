using CodeBase.Infrastructure.Services.InputService;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Player
{
  public class PlayerRotate : MonoBehaviour
  {
    [SerializeField] private float rotateSpeed = 150;
    private IInputService _inputService;

    [Inject]
    public void Construct(IInputService inputService)
    {
      _inputService = inputService;
    }

    private void FixedUpdate()
    {
      if (IsInputAxisX())
        RotateZByFrameAngle();
    }

    private bool IsInputAxisX() => 
      InputAxisX() != 0;

    private void RotateZByFrameAngle() => 
      transform.Rotate(0,0, RotatingAngel());

    private float RotatingAngel() => 
      -Mathf.Sign(InputAxisX())  * rotateSpeed * Time.fixedDeltaTime;

    private float InputAxisX() => 
      _inputService.MoveVector.x;
  }
}