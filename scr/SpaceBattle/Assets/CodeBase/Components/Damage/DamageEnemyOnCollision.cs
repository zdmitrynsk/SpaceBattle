using CodeBase.Components.Death;
using CodeBase.Components.Observers;
using UnityEngine;

namespace CodeBase.Components.Damage
{
  [RequireComponent(typeof(TriggerObserver))]
  public class DamageEnemyOnCollision : MonoBehaviour
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