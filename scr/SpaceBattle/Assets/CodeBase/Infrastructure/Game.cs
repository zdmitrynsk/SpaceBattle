using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.Logic;
using Zenject;

namespace CodeBase.Infrastructure
{
  public class Game
  {
    public readonly GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
    {
      StateMachine = CreateStateMachine(coroutineRunner, curtain, ProjectContainer());
    }

    private static DiContainer ProjectContainer()
    {
      ProjectContext projectContext = ProjectContext.Instance;
      projectContext.ParentNewObjectsUnderContext = false;
      return projectContext.Container;
    }

    private static GameStateMachine CreateStateMachine(ICoroutineRunner coroutineRunner, LoadingCurtain curtain,
      DiContainer container)
    {
      GameStateMachine gameStateMachine = new GameStateMachine();
      gameStateMachine.Add(typeof(BootstrapState),
        new BootstrapState(gameStateMachine, new SceneLoader(coroutineRunner), container, curtain));
      gameStateMachine.Add(typeof(LoadGameSceneState), container.Instantiate<LoadGameSceneState>());
      gameStateMachine.Add(typeof(StartGameState), container.Instantiate<StartGameState>());
      gameStateMachine.Add(typeof(LevelTitleState), container.Instantiate<LevelTitleState>());
      gameStateMachine.Add(typeof(AsteroidsState), container.Instantiate<AsteroidsState>());
      gameStateMachine.Add(typeof(GameOverState), container.Instantiate<GameOverState>());
      return gameStateMachine;
    }
  }
}