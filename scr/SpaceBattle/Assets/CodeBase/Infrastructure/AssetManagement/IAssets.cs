using System.Threading.Tasks;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Infrastructure.AssetManagement
{
  public interface IAssets : IService
  {
    void Initialize();
    Task<T> Load<T>(AssetReference assetReference) where T : class;
    Task<T> Load<T>(string address) where T : class;
    void CleanUp();
    Task<GameObject> Instantiate(string address);
    Task<GameObject> Instantiate(string address, Transform parent);
    Task<GameObject> Instantiate(string address, Vector3 at);
    Task<GameObject> Instantiate(string address, Vector3 at, Quaternion quaternion);
  }
}