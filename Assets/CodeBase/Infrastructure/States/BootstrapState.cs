using System.Net.Mime;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.StaticData;
using CodeBase.UI.Services.Factory;

namespace CodeBase.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private const string InitialScene = "Initial";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly AllServices _services;


    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _services = services;

      RegisterServices();
    }

    public void Enter() => 
      _sceneLoader.Load(InitialScene, onLoaded: EnterLoadLevel);

    public void Exit()
    {
    }

    private void EnterLoadLevel() => 
      _stateMachine.Enter<LoadGameState>();

    private void RegisterServices()
    {
      _services.RegisterSingle((IStaticDataService) new StaticDataService());
      _services.RegisterSingle<IGameStateMachine>(_stateMachine);
      _services.RegisterSingle<IRandomService>(new UnityRandomService());
      RegisterAssetProvider();
      _services.RegisterSingle<IUIFactory>(new UIFactory(
        _services.Single<IAssets>(),
        _services.Single<IStaticDataService>()
      ));
      _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>(),
        _services.Single<IStaticDataService>(), _services.Single<IRandomService>()));
    }
    
    private void RegisterAssetProvider()
    {
      var assetProvider = new AssetProvider();
      assetProvider.Initialize();
      _services.RegisterSingle<IAssets>(assetProvider);
    }
  }
}