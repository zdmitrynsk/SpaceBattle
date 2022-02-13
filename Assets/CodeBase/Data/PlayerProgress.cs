using System;

namespace CodeBase.Data
{
  [Serializable]
  public class PlayerProgress 
  {
    [NonSerialized] public CurrentGameData CurrentGameData;
    
    public PlayerProgress()
    {
      CurrentGameData = new CurrentGameData();
    }
  }
}