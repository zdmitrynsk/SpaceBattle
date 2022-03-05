using UnityEngine;

namespace CodeBase.Components.Damage
{
  [RequireComponent(typeof(Health))]
  public class FxOnDamage : MonoBehaviour
  {
    [SerializeField] private Health health;
    [SerializeField] private GameObject fxDamage;

    private void Awake()
    {
      health.Changed += HealthChanged;
    }

    private void HealthChanged(MonoBehaviour healthChanger) => 
      Instantiate(fxDamage, transform.position, Quaternion.identity, transform);
  }
}