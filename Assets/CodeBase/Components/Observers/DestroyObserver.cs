using System;
using UnityEngine;

namespace CodeBase.Components.Observers
{
  public class DestroyObserver : MonoBehaviour
  {
    public event Action<GameObject> OnHappened;

    private void OnDestroy() => 
      OnHappened?.Invoke(gameObject); 
  }
}