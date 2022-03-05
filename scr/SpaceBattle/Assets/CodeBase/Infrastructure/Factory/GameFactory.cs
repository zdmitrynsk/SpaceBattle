using System.Threading.Tasks;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.RandomService;
using CodeBase.Spawners;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
  class GameFactory : IGameFactory
  {
    private readonly IAssets _assets;
    private readonly IStaticDataService _staticDataService;
    private readonly IRandomService _randomService;
    private readonly DiContainer _container;

    public GameObject Player { get; private set; }

    public GameFactory(IAssets assets, IStaticDataService staticDataService, IRandomService randomService,
      DiContainer container)
    {
      _assets = assets;
      _staticDataService = staticDataService;
      _randomService = randomService;
      _container = container;
    }

    public async Task<GameObject> CreateHud() => 
      await _assets.Instantiate(AssetAddresses.Hud);
    
    public async Task<GameObject> CreatePlayer(Vector3 at)
    {
      Player = await _assets.Instantiate(AssetAddresses.PlayerAddress, at);
      return Player;
    }

    public async Task<GameObject> CreateBullet(Vector3 at, Quaternion quaternion) => 
      await _assets.Instantiate(AssetAddresses.BulletAddress, at, quaternion);

    public AsteroidSpawner CreateAsteroidSpawner(int healthAsteroid)
    {
      AsteroidSpawner asteroidSpawner = _container.Instantiate<AsteroidSpawner>();
      asteroidSpawner.SetHealthAsteroid(healthAsteroid);
      return asteroidSpawner;
    }

    public async Task<GameObject> CreateAsteroid() => 
      await _assets.Instantiate(AssetAddresses.Asteroid);
  }
}