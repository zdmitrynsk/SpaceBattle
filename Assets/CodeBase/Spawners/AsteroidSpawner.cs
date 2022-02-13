using System.Collections;
using System.Collections.Generic;
using CodeBase.Components;
using CodeBase.Components.Observers;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.RandomService;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Spawners
{
  public class AsteroidSpawner
  {
    private Coroutine _spawnCoroutine;
    private List<GameObject> _asteroids;
    private IGameFactory _gameFactory;
    private IRandomService _randomService;
    private ICoroutineRunner _coroutineRunner;
    private AsteroidSpawnerData _spawnerData;
    private Camera _camera;
    private int _healthAsteroid;


    [Inject]
    public void Construct(IGameFactory gameFactory, IRandomService randomService, ICoroutineRunner coroutineRunner,
      IStaticDataService staticDataService)
    {
      _gameFactory = gameFactory;
      _randomService = randomService;
      _coroutineRunner = coroutineRunner;
      _spawnerData = staticDataService.AsteroidSpawnerData;

      _asteroids = new List<GameObject>(_spawnerData.maxAsteroids);
      _camera = Camera.main;
    }

    public void SetHealthAsteroid(int levelDifficult) =>
      _healthAsteroid = levelDifficult;

    public void StartSpawning() =>
      _spawnCoroutine = _coroutineRunner.StartCoroutine(LoopSpawn());

    public void Destroy()
    {
      DestroyAsteroids();
      StopSpawning();
    }

    private void DestroyAsteroids()
    {
      foreach (GameObject asteroid in _asteroids)
        Object.Destroy(asteroid);
    }

    private void StopSpawning()
    {
      if (_spawnCoroutine == null)
        return;
      _coroutineRunner.StopCoroutine(_spawnCoroutine);
      _spawnCoroutine = null;
    }

    private IEnumerator LoopSpawn()
    {
      while (true)
      {
        yield return new WaitForSeconds(RandomDelay());
        if (!IsReachMaxAsteroids()) 
          SpawnAsteroid();
      }
    }

    private bool IsReachMaxAsteroids() => 
      _asteroids.Count >= _spawnerData.maxAsteroids;

    private float RandomDelay() =>
      _randomService.Next(_spawnerData.minDelay, _spawnerData.maxDelay);

    private async void SpawnAsteroid()
    {
      GameObject asteroid = await _gameFactory.CreateAsteroid();
      asteroid.transform.position = RandomRightPosition();
      asteroid.GetComponent<ObserverDestroy>().OnHappened += OnDestroyAsteroid;
      Health health = asteroid.GetComponent<Health>();
      health.Max = _healthAsteroid;
      health.Current = health.Max;
      _asteroids.Add(asteroid);
    }

    private Vector3 RandomRightPosition()
    {
      var randomRightPosition = new Vector3(
        Screen.width,
        _randomService.Next(0, Screen.height));
      Vector3 worldPoint = _camera.ScreenToWorldPoint(randomRightPosition);
      worldPoint.z = 0;
      return worldPoint;
    }

    private void OnDestroyAsteroid(GameObject asteroid)
    {
      asteroid.GetComponent<ObserverDestroy>().OnHappened -= OnDestroyAsteroid;
      _asteroids.Remove(asteroid);
    }
  }
}