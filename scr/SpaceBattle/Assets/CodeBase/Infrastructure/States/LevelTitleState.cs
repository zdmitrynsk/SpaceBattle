using System;
using System.Threading.Tasks;
using CodeBase.UI.Services.Factory;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  public class LevelTitleState :  IPayloadedState<IPayloadedState<int>, int>
  {
    private readonly IUIFactory _uiFactory;
    private IGameStateMachine _gameStateMachine;

    private const string Title = "LEVEL {0}";

    public LevelTitleState(IUIFactory uiFactory, IGameStateMachine gameStateMachine)
    {
      _gameStateMachine = gameStateMachine;
      _uiFactory = uiFactory;
    }
    
    public async void Enter<TPayload>(int levelDifficult) 
      where TPayload : class, IPayloadedState<int>
    {
      await ShowTitle(levelDifficult);
      EnterNextState<TPayload, int>(levelDifficult);
    }

    private async Task ShowTitle(int levelDifficult)
    {
      GameObject titleLevel = await _uiFactory.CreateTitleLevel(levelDifficult);
      var textMeshProUGUI = titleLevel.GetComponent<TextMeshProUGUI>();
      textMeshProUGUI.SetText(Title, levelDifficult);
      await FadeInOutTextColor(textMeshProUGUI);
      GameObject.Destroy(titleLevel);
    }

    private static async Task FadeInOutTextColor(TextMeshProUGUI textMeshProUGUI)
    {
      var transparentColor = new Color(0, 0, 0, 0);
      textMeshProUGUI.color = transparentColor;
      await Task.Delay(TimeSpan.FromSeconds(1));
      await textMeshProUGUI.DOColor(Color.white, 2f).AsyncWaitForCompletion();
      await textMeshProUGUI.DOColor(transparentColor, 1f).AsyncWaitForCompletion();
    }

    private void EnterNextState<TState, TState2>(TState2 payload) 
      where TState : class, IPayloadedState<TState2> =>
      _gameStateMachine.Enter<TState, TState2>(payload);

    public void Exit()
    {
    }
  }
}