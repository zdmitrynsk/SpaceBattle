using UnityEngine;

namespace CodeBase.Components.Death
{
  public class FxOnDestroy : MonoBehaviour
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