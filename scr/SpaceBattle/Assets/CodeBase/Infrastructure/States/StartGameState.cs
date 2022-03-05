using CodeBase.Infrastructure.Factory;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  internal class StartGameState : IState
  {
    private readonly IGameStateMachine _gameStateMachine;
    private readonly ILoadingCurtain _curtain;
    private readonly ISceneLoader _sceneLoader;
    private readonly IGameFactory _gameFactory;
    private GameObject _player;

    public StartGameState(IGameStateMachine gameStateMachine, ILoadingCurtain curtain,
      IGameFactory gameFactory)
    {
      _gameStateMachine = gameStateMachine;
      _curtain = curtain;
      _gameFactory = gameFactory;
    }

    public async void Enter()
    {
      _curtain.Show();
      await _gameFactory.CreatePlayer(Vector3.zero);
      await _curtain.Hide();
      _gameStateMachine.Enter<LevelTitleState, AsteroidsState, int>(1);
    }

    public void Exit()
    {
    }
  }
}