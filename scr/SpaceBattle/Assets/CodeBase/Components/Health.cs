using System;
using CodeBase.Components.Damage;
using UnityEngine;

namespace CodeBase.Components
{
  public class Health : MonoBehaviour
  {
    [SerializeField] private float _current;
    [SerializeField] private float _max;
    public event Action<DamageEnemyHealthBase> Changed;

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

    public void TakeDamage(DamageEnemyHealthBase healthChanger, float damage)
    {
      Current -= damage;
      Changed?.Invoke(healthChanger);
    }
  }
}