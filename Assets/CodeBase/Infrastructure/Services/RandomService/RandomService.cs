using UnityEngine;

namespace CodeBase.Infrastructure.Services.RandomService
{
  public class RandomService : IRandomService
  {
    public int Next(int min, int max) => 
      Random.Range(min, max);

    public float Next(float min, float max) => 
      Random.Range(min, max);
  }
}