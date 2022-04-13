using CodeBase.Components.Observers;
using UnityEngine;

namespace CodeBase.Components.Damage
{
  public abstract class DamageEnemyHealthBase : MonoBehaviour
  {
    [SerializeField] private TriggerObserver triggerObserver;
    [SerializeField] private float damage;

    private void Awake()
    {
      triggerObserver.TriggerEnter += EnterTrigger;
    }

    private void OnDestroy()
    {
      triggerObserver.TriggerEnter -= EnterTrigger;
    }

    private void EnterTrigger(Collider2D obj) =>
      obj.GetComponent<Health>()?.TakeDamage(this, damage);
  }
}