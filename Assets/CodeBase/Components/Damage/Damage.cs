using CodeBase.Components.Observers;
using UnityEngine;

namespace CodeBase.Components.Damage
{
  [RequireComponent(typeof(ObserverTrigger))]
  public class Damage : MonoBehaviour
  {
    [SerializeField] private ObserverTrigger observerTrigger;
    
    public float Amount;

    private void Awake()
    {
      observerTrigger.TriggerEnter += TriggerEnter;
    }

    private void OnDestroy()
    {
      observerTrigger.TriggerEnter -= TriggerEnter;
    }

    private void TriggerEnter(Collider2D obj) => 
      obj.GetComponent<Health>()?.TakeDamage(Amount);
  }
}