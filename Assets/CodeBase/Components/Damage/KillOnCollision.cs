using CodeBase.Components.Death;
using CodeBase.Components.Observers;
using UnityEngine;

namespace CodeBase.Components.Damage
{
  [RequireComponent(typeof(ObserverTrigger))]
  public class KillOnCollision : MonoBehaviour
  {
    [SerializeField] private ObserverTrigger observerTrigger;

    private void Awake()
    {
      observerTrigger.TriggerEnter += TriggerEnter;
    }

    private void OnDestroy()
    {
      observerTrigger.TriggerEnter -= TriggerEnter;
    }

    private void TriggerEnter(Collider2D obj) =>
      obj.GetComponent<DeathOnCollision>()?.Kill();
  }
}