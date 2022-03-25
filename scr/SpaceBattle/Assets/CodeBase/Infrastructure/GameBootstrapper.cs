using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure
{
  public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
  {
    [SerializeField] private LoadingCurtain curtainPrefab;
    private Game _game;

    private void Awake()
    {
      _game = new Game(this, Instantiate(curtainPrefab));
      _game.StateMachine.Enter<BootstrapState>();

      DontDestroyOnLoad(this);
    }
  }
}