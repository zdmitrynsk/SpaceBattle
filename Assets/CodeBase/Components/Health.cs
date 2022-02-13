using System;
using UnityEngine;

namespace CodeBase.Components
{
  public class Health : MonoBehaviour
  {
    [SerializeField] private float _current;
    [SerializeField] private float _max;
    public event Action Changed;

    public float Current
    {
      get => _current;
      set => _current = value;
    }

    public float Max
    {
      get => _max;
      set => _max = value;
    }

    public void TakeDamage(float damage)
    {
      Current -= damage;
      Changed?.Invoke();
    }
  }
}