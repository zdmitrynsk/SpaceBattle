using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Player
{
  public class AttackPlayer : MonoBehaviour
  {
    [SerializeField] private float speedBullet = 15;
    [SerializeField] private float cooldownSec;
    
    private IGameFactory _gameFactory;
    private IInputService _input;
    private float _lastShotTime;
    private int _bulletsCount;

    [Inject]
    public void Construct(IGameFactory gameFactory, IInputService input)
    {
      _gameFactory = gameFactory;
      _input = input;
    }

    private void Update()
    {
      if (IsAttackPressed() && IsReadyCooldown()) 
        Fire();
    }

    private bool IsAttackPressed() => 
      _input.IsAttackButtonDown;

    private bool IsReadyCooldown() => 
      Time.realtimeSinceStartup - _lastShotTime > cooldownSec;

    private async void Fire()
    {
      _lastShotTime = Time.realtimeSinceStartup;
      var bullet = await _gameFactory.CreateBullet(ShotPosition(), transform.rotation);
      bullet.GetComponent<Move.Move>().MovementSpeedVector = transform.up * speedBullet;
    }

    private Vector3 ShotPosition()
    {
      Vector3 position = transform.position + (transform.up * 0.5f) + transform.forward * 0.5f;
      position.z = 0;
      return position;
    }
  }
}