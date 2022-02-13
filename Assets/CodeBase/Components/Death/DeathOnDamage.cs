using System;
using UnityEngine;

namespace CodeBase.Components.Death
{
  [RequireComponent(typeof(Health))]
  public class DeathOnDamage : MonoBehaviour
  {
    [SerializeField] private Health health;
    public event Action<GameObject> OnHappened;

    private void Awake() => 
      health.Changed += HealthChanged;

    private void OnDestroy() => 
      health.Changed -= HealthChanged;

    private void HealthChanged()
    {
      if (health.Current <= 0) 
        Die();
    }

    private void Die()
    {
      health.Changed -= HealthChanged;
      Destroy(gameObject);
      OnHappened?.Invoke(gameObject);
    }
    
  }
}