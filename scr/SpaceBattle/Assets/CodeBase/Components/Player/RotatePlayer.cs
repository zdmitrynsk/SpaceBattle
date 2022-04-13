using CodeBase.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Player
{
  public class RotatePlayer : MonoBehaviour
  {
    [SerializeField] private float rotateSpeed = 150;
    [SerializeField] private Rigidbody2D _rigidbody2D;
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
      _rigidbody2D.MoveRotation(RotatingAngel());

    private float RotatingAngel() => 
      transform.rotation.eulerAngles.z - Mathf.Sign(InputAxisX()) * rotateSpeed * Time.fixedDeltaTime;

    private float InputAxisX() => 
      _inputService.MoveVector.x;
  }
}