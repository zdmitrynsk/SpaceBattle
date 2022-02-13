using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.Infrastructure.Services.InputService
{
  public class InputService : MonoBehaviour, IInputService
  {

    [SerializeField] private PlayerInput input;

    
    private InputAction _moveAction;
    private InputAction _fireAction;

    public Vector2 MoveVector => 
      _moveAction.ReadValue<Vector2>();

    public bool IsAttackButtonDown => 
      _fireAction.ReadValue<float>() > 0;

    private void Awake()
    {
      _fireAction = input.actions["fire"];
      _moveAction = input.actions["move"];
      DontDestroyOnLoad(this);
    }

    private void Update()
    {
      
    }
  }
}