using System;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;
using CodeBase.StaticData;
using CodeBase.UI.Services.Factory;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
  public class BootstrapState : IState
  {
    private const string InitialScene = "Initial";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly DiContainer _container;
    private readonly ILoadingCurtain _loadingCurtain;


    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, DiContainer container,
      ILoadingCurtain loadingCurtain)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _container = container;
      _loadingCurtain = loadingCurtain;

      RegisterServices();
    }

    public void Enter() =>
      _sceneLoader.Load(InitialScene, onLoaded: EnterLoadLevel);

    public void Exit()
    {
    }

    private void EnterLoadLevel() => 
      _stateMachine.Enter<LoadGameSceneState>();

    private void RegisterServices()
    {
      _container.Bind<IGameStateMachine>().FromInstance(_stateMachine).AsSingle().NonLazy();
      _container.Bind<ILoadingCurtain>().FromInstance(_loadingCurtain).AsSingle().NonLazy();
      _container.Bind<ISceneLoader>().FromInstance(_sceneLoader).AsSingle().NonLazy();
      _container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle().OnInstantiated(LoadStaticData()).NonLazy();
      _container.Bind<IRandomService>().To<RandomService>().AsSingle().NonLazy();
      _container.Bind<IAssets>().To<AssetProvider>().AsSingle().OnInstantiated(InitAssetProvider()).NonLazy();
      _container.Bind<IUIFactory>().To<UIFactory>().AsSingle().NonLazy();
      _container.Bind<IGameFactory>().To<GameFactory>().AsSingle().NonLazy();
      _container.Bind<IInputService>().To<InputService>().FromMethod(InputService).AsSingle().NonLazy();
      _container.Bind<IProgressService>().To<ProgressService>().AsSingle().NonLazy();
      _container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromMethod(CoroutineRunner).AsSingle().NonLazy();
    }

    private static Action<InjectContext, object> LoadStaticData() => 
      (_, obj) => (obj as IStaticDataService).LoadData();

    private static Action<InjectContext, object> InitAssetProvider() => 
      (_, obj) => (obj as IAssets).Initialize();

    private InputService InputService()
    {
      InputService prefab = Resources.Load<InputService>("Infastucture/Services/InputService");
      return GameObject.Instantiate(prefab);
    }

    private CoroutineRunner CoroutineRunner()
    {
      CoroutineRunner prefab = Resources.Load<CoroutineRunner>("Infastucture/Services/CoroutineRunner");
      return GameObject.Instantiate(prefab);
    }
  }
}