using System.Threading.Tasks;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Services.Factory
{
  public class UIFactory : IUIFactory
  {
    private IAssets _assets;
    private Transform _uiRoot;
    private IStaticDataService _staticDataService;
    private DiContainer _container;

    public UIFactory(IAssets assets, IStaticDataService staticDataService, DiContainer container)
    {
      _container = container;
      _staticDataService = staticDataService;
      _assets = assets;
    }

    public async Task CreateUIRoot()
    {
      GameObject root = await _assets.Instantiate(AssetAddresses.UiRoot);
      _uiRoot = root.transform;
    }

    public async Task<GameObject> CreateGameOverWindow() => 
      await _assets.Instantiate(AssetAddresses.GameOverWindow, _uiRoot);

    public async Task<GameObject> CreateTitleLevel(int levelDifficult) => 
      await _assets.Instantiate(AssetAddresses.TitleLevel, _uiRoot);
  }
}