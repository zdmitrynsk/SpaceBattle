using CodeBase.Components.Death;
using CodeBase.Components.Observers;
using UnityEngine;

namespace CodeBase.Components.Damage
{
  [RequireComponent(typeof(TriggerObserver))]
  public class KillOnCollision : MonoBehaviour
  {
    [SerializeField] private TriggerObserver triggerObserver;

    private void Awake()
    {
      triggerObserver.TriggerEnter += Enter;
    }

    private void OnDestroy()
    {
      triggerObserver.TriggerEnter -= Enter;
    }

    private void Enter(Collider2D obj) =>
      obj.GetComponent<DeathOnCollision>()?.Kill();
  }
}