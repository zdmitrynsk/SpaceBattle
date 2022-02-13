using UnityEngine;

namespace CodeBase.Components.Move
{
  [RequireComponent(typeof(Move))]
  public class DecelerateSpeed : MonoBehaviour
  {
    [SerializeField] private Move move;
    [SerializeField] private float decelerationValue = 0.7f;

    private void FixedUpdate()
    {
      Decelerate();
    }

    private void Decelerate()
    {
      
      var deceleration = Abs(move.MovementSpeedVector) * decelerationValue;
      move.SpeedDown(deceleration * Time.fixedDeltaTime);
    }

    private static Vector2 Abs(Vector2 transformUp) => 
      new Vector2(Mathf.Abs(transformUp.x), Mathf.Abs(transformUp.y));
  }
}