using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  public class UnityRandomService : IRandomService
  {
    public int Next(int min, int max) => 
      Random.Range(min, max);
  }
}