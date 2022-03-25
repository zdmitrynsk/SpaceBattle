using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator coroutine);
    void StopCoroutine(Coroutine coroutine);
  }
}