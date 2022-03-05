using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
  public class WindowBase : MonoBehaviour
  {
    public Button CloseButton;

    private void Awake() =>
      OnAwake();

    private void Start()
    {
      Initialize();
      SubscribeUpdates();
    }

    private void OnDestroy() =>
      Cleanup();

    protected virtual void OnAwake() =>
      CloseButton.onClick.AddListener(() => Destroy(gameObject));

    protected virtual void Initialize()
    {
    }

    protected virtual void SubscribeUpdates()
    {
    }

    protected virtual void Cleanup()
    {
    }
  }
}