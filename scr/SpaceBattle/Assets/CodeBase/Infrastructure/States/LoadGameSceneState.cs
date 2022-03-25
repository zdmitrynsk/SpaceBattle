using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
  public class LoadGameSceneState : IState
  {
    private const string GameScene = "Game";
    
    private readonly IUIFactory _uiFactory;
    private readonly IGameFactory _gameFactory;
    private readonly IGameStateMachine _stateMachine;
    private readonly ILoadingCurtain _curtain;
    private readonly ISceneLoader _sceneLoader;

    public LoadGameSceneState(IUIFactory uiFactory, IGameFactory gameFactory, IGameStateMachine stateMachine,
      ILoadingCurtain curtain, ISceneLoader sceneLoader)
    {
      _uiFactory = uiFactory;
      _gameFactory = gameFactory;
      _stateMachine = stateMachine;
      _curtain = curtain;
      _sceneLoader = sceneLoader;
    }

    public async void Enter()
    {
      _sceneLoader.Load(GameScene, OnLoaded);
    }

    private async void OnLoaded()
    {
      _curtain.Show();
      await _uiFactory.CreateUIRoot();
      await _gameFactory.CreateHud();
      _stateMachine.Enter<StartGameState>();
    }

    public void Exit()
    {
    }
  }
}