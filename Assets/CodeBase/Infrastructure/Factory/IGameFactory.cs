using System.Threading.Tasks;
using CodeBase.Infrastructure.Services;
using CodeBase.Spawners;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
  public interface IGameFactory : IService
  {
    Task<GameObject> CreatePlayer(Vector3 at);
    Task<GameObject> CreateBullet(Vector3 at, Quaternion quaternion);
    AsteroidSpawner CreateAsteroidSpawner(int healthAsteroid);
    Task<GameObject> CreateAsteroid();
    Task<GameObject> CreateHud();
    GameObject Player { get; }
  }
}