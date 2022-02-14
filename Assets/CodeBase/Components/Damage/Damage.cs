using CodeBase.Components.Observers;
using UnityEngine;

namespace CodeBase.Components.Damage
{
  [RequireComponent(typeof(TriggerObserver))]
  public class Damage : MonoBehaviour
  {
    [SerializeField] private TriggerObserver triggerObserver;
    
    public float Amount;

    private void Awake()
    {
      triggerObserver.TriggerEnter += Enter;
    }

    private void OnDestroy()
    {
      triggerObserver.TriggerEnter -= Enter;
    }

    private void Enter(Collider2D obj) => 
      obj.GetComponent<Health>()?.TakeDamage(Amount);
  }
}