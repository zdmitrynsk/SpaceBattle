using UnityEngine;

namespace CodeBase.Components.Death
{
  public class DeathOnCollision : MonoBehaviour
  {
    public void Kill() => 
      Die();

    private void Die() => 
      Destroy(gameObject);
  }
}