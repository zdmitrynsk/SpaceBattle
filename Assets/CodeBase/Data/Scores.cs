using System;

namespace CodeBase.Data
{
  public class Scores
  {
    public Action OnChanged;

    public int Collected { get; private set; }

    public void Add(int scores)
    {
      Collected += scores;
      OnChanged?.Invoke();
    }

    public void Reset()
    {
      Collected = 0;
      OnChanged?.Invoke();
    }
  }
}