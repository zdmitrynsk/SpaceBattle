using CodeBase.Infrastructure.Services;
using UnityEngine.InputSystem;

namespace CodeBase.StaticData
{
  public interface IStaticDataService : IService
  {
    void LoadData();
    InputActionAsset ActionAsset { get; }
    AsteroidSpawnerData AsteroidSpawnerData { get; }
  }
}