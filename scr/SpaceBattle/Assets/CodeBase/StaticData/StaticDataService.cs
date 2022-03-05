using UnityEngine;
using UnityEngine.InputSystem;

namespace CodeBase.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private const string InputActionAssetStaticData = "StaticData/SpaceBattle.inputactions";
    private const string AsteroidSpawnerStaticData = "StaticData/AsteroidSpawner";

    public InputActionAsset ActionAsset { get; private set; }
    public AsteroidSpawnerData AsteroidSpawnerData { get; private set; }


    public void LoadData()
    {
      ActionAsset = Resources.Load<InputActionAsset>(InputActionAssetStaticData);
      AsteroidSpawnerData = Resources.Load<AsteroidSpawnerData>(AsteroidSpawnerStaticData);
    }
  }
}