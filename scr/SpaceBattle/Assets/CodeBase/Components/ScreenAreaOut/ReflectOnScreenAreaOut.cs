using UnityEngine;

namespace CodeBase.Components.ScreenAreaOut
{
  [RequireComponent(typeof(Move.Move))]
  public class ReflectOnScreenAreaOut : MonoBehaviour
  {
    [SerializeField] private Move.Move move;
    private Rect _worldArea;
    private bool _isOuted;

    private void Awake()
    {
      _worldArea = WorldAreaOfScreen();
    }

    private void Update()
    {
      if (IsOutArea())
      {
        if (_isOuted == false)
        {
          move.MovementSpeedVector *= -1;
          _isOuted = true;
        }
      }
      else
      {
        _isOuted = false;
      }
    }

    private static Rect WorldAreaOfScreen() =>
      new Rect
      {
        min = Camera.main.ScreenToWorldPoint(new Vector3(0, 0)),
        max = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height))
      };

    private bool IsOutArea() =>
      IsOutAxis(transform.position.x, _worldArea.xMin, _worldArea.xMax)
      || IsOutAxis(transform.position.y, _worldArea.yMin, _worldArea.yMax);


    private bool IsOutAxis(float position, float Min, float Max) =>
      position < Min || position > Max;
  }
}