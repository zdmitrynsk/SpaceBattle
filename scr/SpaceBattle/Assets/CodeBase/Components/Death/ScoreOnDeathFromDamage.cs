using CodeBase.Components.Damage;
using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Components.Death
{

  [RequireComponent(typeof(Death))]
  public class ScoreOnDeathFromDamage : MonoBehaviour
  {
    [SerializeField] private Death death;
    [SerializeField] private int reward;
    
    private Scores _scores;

    [Inject]
    public void Construct(IProgressService progressService) => 
      _scores = progressService.Progress.CurrentGameData.Scores;

    private void Awake() =>
      death.OnHappened += OnDeath;

    private void OnDeath(MonoBehaviour killer)
    {
      if (killer is DamageEnemyHealthAsDefault)
        _scores.Add(reward);
    }
  }
}