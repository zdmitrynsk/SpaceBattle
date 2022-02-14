using System;
using UnityEngine;

namespace CodeBase.Components.Death
{
  [RequireComponent(typeof(Health))]
  public class Death : MonoBehaviour
  {
    [SerializeField] private Health health;
    public event Action<MonoBehaviour> OnHappened;

    private void Awake()
    {
      health.Changed += HealthChanged;
    }

    private void OnDestroy()
    {
      health.Changed -= HealthChanged;
    }

    private void HealthChanged(MonoBehaviour healthChanger)
    {
      if (health.Current <= 0)
      {
        Destroy(gameObject);
        OnHappened?.Invoke(healthChanger);
      }
    }
  }
}