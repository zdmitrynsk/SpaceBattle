using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.States;
using CodeBase.StaticData;

namespace CodeBase.Infrastructure.Factory
{
  class GameFactory : IGameFactory
  {
    private readonly IAssets _single;
    private readonly IStaticDataService _staticDataService;
    private readonly IRandomService _randomService;

    public GameFactory(IAssets single, IStaticDataService staticDataService, IRandomService randomService)
    {
      _single = single;
      _staticDataService = staticDataService;
      _randomService = randomService;
    }
  }
}