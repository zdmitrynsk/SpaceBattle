using CodeBase.Components.Death;
using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Components
{

  [RequireComponent(typeof(DeathOnDamage))]
  public class ScoreOnDeathFromDamage : MonoBehaviour
  {
    [SerializeField] private DeathOnDamage deathOnDamage;
    [SerializeField] private int reward;
    
    private Scores _scores;

    [Inject]
    public void Construct(IProgressService progressService) => 
      _scores = progressService.Progress.CurrentGameData.Scores;

    private void Awake() => 
      deathOnDamage.OnHappened += OnDeathByDamage;

    private void OnDeathByDamage(GameObject obj) => 
      _scores.Add(reward);
  }
}