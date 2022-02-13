namespace CodeBase.Data
{
  public class CurrentGameData
  {
    public Scores Scores;

    public CurrentGameData() => 
      Scores = new Scores();

    public void Reset()
    {
      Scores.Reset();
    }
  }
}