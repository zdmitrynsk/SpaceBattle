using UnityEngine;

namespace CodeBase.Components.Move
{
  public class Move : MonoBehaviour
  {
    [SerializeField] private float maxSpeed = float.MaxValue;
    [SerializeField] private Vector2 _movementSpeedVector = Vector2.zero;
    [SerializeField] private Rigidbody2D rigidbody2D;

    public Vector2 MovementSpeedVector
    {
      get => _movementSpeedVector;
      set
      {
        if (value.magnitude > maxSpeed)
          value *= maxSpeed / value.magnitude;
        _movementSpeedVector = value;
      }
    }

    private void OnValidate()
    {
      MovementSpeedVector = _movementSpeedVector;
    }

    private void FixedUpdate()
    {
      MoveByFrameDistance();
    }
    
    public void SpeedUp(Vector2 value) => 
      MovementSpeedVector += value;

    public void SpeedDown(Vector2 value) =>
      MovementSpeedVector = new Vector2(
        DownToZero(_movementSpeedVector.x, value.x),
        DownToZero(_movementSpeedVector.y, value.y));

    private void MoveByFrameDistance()
    {
      Vector3 distance = MovementSpeedVector * Time.fixedDeltaTime;
      rigidbody2D.MovePosition(transform.position += distance);
    }

    private static float DownToZero(float baseValue, float downValue)
    {
      if (baseValue == 0) 
        return 0;

      float result;
      if (Mathf.Sign(baseValue) > 0)
        result = Mathf.Clamp(baseValue - downValue, 0, float.MaxValue);
      else
        result = Mathf.Clamp(baseValue + downValue, float.MinValue, 0);

      return result;
    }
  }
}