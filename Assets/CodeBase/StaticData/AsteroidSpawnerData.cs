using UnityEngine;

namespace CodeBase.StaticData
{
  [CreateAssetMenu(fileName = "AsteroidSpawner", menuName = "StaticData/Spawners")]
  public class AsteroidSpawnerData : ScriptableObject
  {
    public float minDelay = 3;
    public float maxDelay = 5;
    public int maxAsteroids = 3;
  }
}