using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace CodeBase.Infrastructure.AssetManagement
{
public class AssetProvider : IAssets
  {
    private readonly Dictionary<string, AsyncOperationHandle> _completedCache = new Dictionary<string, AsyncOperationHandle>();
    private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new Dictionary<string, List<AsyncOperationHandle>>();
    private DiContainer _container;

    public AssetProvider(DiContainer container)
    {
      _container = container;
    }

    public void Initialize() =>
      Addressables.InitializeAsync();

    public async Task<T> Load<T>(AssetReference assetReference) where T : class
    {
      if (_completedCache.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle completedHandle))
        return completedHandle.Result as T;

      return await RunWithCacheOnComplete(
        Addressables.LoadAssetAsync<T>(assetReference),
        cacheKey: assetReference.AssetGUID);
    }

    public async Task<T> Load<T>(string address) where T : class
    {
      if (_completedCache.TryGetValue(address, out AsyncOperationHandle completedHandle))
        return completedHandle.Result as T;

      return await RunWithCacheOnComplete(
        Addressables.LoadAssetAsync<T>(address),
        cacheKey: address);
    }

    public async Task<GameObject> Instantiate(string address)
    {
      GameObject prefab = await Load<GameObject>(address);
      GameObject gameObject = GameObject.Instantiate(prefab);
      _container.InjectGameObject(gameObject);
      return gameObject;
    }

    public async Task<GameObject> Instantiate(string address, Transform parent)
    {
      GameObject prefab = await Load<GameObject>(address);
      GameObject gameObject = Object.Instantiate(prefab, parent);
      _container.InjectGameObject(gameObject);
      return gameObject;
    }

    public async Task<GameObject> Instantiate(string address, Vector3 at)
    {
        GameObject prefab = await Load<GameObject>(address);
        GameObject gameObject = Object.Instantiate(prefab, at, Quaternion.identity);
        _container.InjectGameObject(gameObject);
        return gameObject;
    }    
    
    public async Task<GameObject> Instantiate(string address, Vector3 at, Quaternion quaternion)
    {
        GameObject prefab = await Load<GameObject>(address);
        GameObject gameObject = Object.Instantiate(prefab, at, quaternion);
        _container.InjectGameObject(gameObject);
        return gameObject;
    }

    public void CleanUp()
    {
      foreach (List<AsyncOperationHandle> resourceHandles in _handles.Values)
        foreach (AsyncOperationHandle handle in resourceHandles)
          Addressables.Release(handle);

      _completedCache.Clear();
      _handles.Clear();
    }

    private async Task<T> RunWithCacheOnComplete<T>(AsyncOperationHandle<T> handle, string cacheKey) where T : class
    {
      handle.Completed += completeHandle => { _completedCache[cacheKey] = completeHandle; };

      AddHandle(cacheKey, handle);
      return await handle.Task;
    }

    private void AddHandle<T>(string key, AsyncOperationHandle<T> handle) where T : class
    {
      if (!_handles.TryGetValue(key, out List<AsyncOperationHandle> resourceHandle))
      {
        resourceHandle = new List<AsyncOperationHandle>();
        _handles[key] = resourceHandle;
      }

      resourceHandle.Add(handle);
    }
  }
}