using CodeBase.UI.Services.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  public class GameOverState : IState
  {
    private readonly IUIFactory _uiFactory;
    private GameObject _window;

    public GameOverState(IUIFactory uiFactory)
    {
      _uiFactory = uiFactory;
    }
    
    public async void Enter()
    {
      _window = await _uiFactory.CreateGameOverWindow();
    }

    public void Exit()
    {

    }
  }
}