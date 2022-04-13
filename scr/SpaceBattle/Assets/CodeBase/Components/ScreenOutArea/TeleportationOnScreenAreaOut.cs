using UnityEngine;

namespace CodeBase.Components.ScreenOutArea
{
  public class TeleportationOnScreenAreaOut : MonoBehaviour
  {
    private Rect _worldArea;

    private void Awake()
    {
      _worldArea = new Rect
      {
        max = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)),
        min = Camera.main.ScreenToWorldPoint(new Vector3(0, 0))
      };
    }

    private void FixedUpdate()
    {
      transform.position = LimitedPosition();
    }

    private Vector3 LimitedPosition() =>
      new Vector3(
        LimitedAxis(transform.position.x, _worldArea.xMin, _worldArea.xMax), 
        LimitedAxis(transform.position.y, _worldArea.yMin, _worldArea.yMax));

    private float LimitedAxis(float position, float Min, float Max)
    {
      var result = position;
      if (position < Min)
        result = Max;
      else if (position > Max)
        result = Min;
      return result;
    }
  }
}