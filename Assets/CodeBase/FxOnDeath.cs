using UnityEngine;

namespace CodeBase
{
  public class FxOnDeath : MonoBehaviour
  {
    [SerializeField] private GameObject deathFx;
    
    private void OnDestroy()
    {
      SpawnDeathFx();
    }
    
    private void SpawnDeathFx() => 
      Instantiate(deathFx, transform.position, Quaternion.identity);
  }
}