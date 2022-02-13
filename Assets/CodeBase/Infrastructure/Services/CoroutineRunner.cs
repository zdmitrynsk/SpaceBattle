using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
  public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
  {
    private void Awake()
    {
      DontDestroyOnLoad(this);
    }
  }
}