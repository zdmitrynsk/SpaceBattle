using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using Zenject;

namespace CodeBase.Infrastructure
{
  public class Game
  {
    public readonly GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
    {
      StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, ProjectContext().Container);
    }

    private static ProjectContext ProjectContext()
    {
      ProjectContext projectContext = Zenject.ProjectContext.Instance;
      projectContext.ParentNewObjectsUnderContext = false;
      return projectContext;
    }
  }
}