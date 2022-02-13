using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Elements
{
  public class ScoreCounter : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI counter;
    private Scores _scores;

    [Inject]
    public void Construct(IProgressService progressService)
    {
      _scores = progressService.Progress.CurrentGameData.Scores;
      _scores.OnChanged += Changed;
    }

    private void OnDestroy()
    {
      _scores.OnChanged += Changed;
    }

    private void Start()
    {
      UpdateCounter();
    }

    private void Changed() => 
      UpdateCounter();

    private void UpdateCounter() => 
      counter.text = $"{_scores.Collected}";
  }
}