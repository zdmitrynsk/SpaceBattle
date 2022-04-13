using CodeBase.Components.Death;
using CodeBase.Data;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Spawners;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.States
{
  public class AsteroidsState : IPayloadedState<int>
  {
    private readonly IGameFactory _gameFactory;
    private readonly IGameStateMachine _gameStateMachine;

    private AsteroidSpawner _asteroidSpawner;

    private int _levelDifficult;
    private readonly Scores _scores;

    private const int ScoresPerLevelDifficult = 100;

    public AsteroidsState(IGameFactory gameFactory, IProgressService progressService,
      IGameStateMachine gameStateMachine)
    {
      _gameFactory = gameFactory;
      _gameStateMachine = gameStateMachine;
      _scores = progressService.Progress.CurrentGameData.Scores;
    }

    public void Enter(int levelDifficult)
    {
      _levelDifficult = levelDifficult;
      InitAsteroidSpawner();
      PlayerDeathComponent().OnHappened += OnDeathPlayer;
      _scores.OnChanged += ChangedScore;
    }

    public void Exit()
    {
      _asteroidSpawner.Destroy();
      PlayerDeathComponent().OnHappened -= OnDeathPlayer;
      _scores.OnChanged -= ChangedScore;
    }

    private void InitAsteroidSpawner()
    {
      _asteroidSpawner = _gameFactory.CreateAsteroidSpawner(_levelDifficult);
      _asteroidSpawner.StartSpawning();
    }

    private Death PlayerDeathComponent() => 
      _gameFactory.Player.GetComponent<Death>();

    private void ChangedScore()
    {
      if (IsReachedNextDifficult(_scores.Collected))
        StartNextDifficult();
    }

    private bool IsReachedNextDifficult(int scoresCollected) =>
      scoresCollected >= _levelDifficult * ScoresPerLevelDifficult;

    private void StartNextDifficult() =>
      _gameStateMachine.Enter<LevelTitleState, AsteroidsState, int>(++_levelDifficult);

    private void OnDeathPlayer(MonoBehaviour obj) => 
      _gameStateMachine.Enter<GameOverState>();
  }
}