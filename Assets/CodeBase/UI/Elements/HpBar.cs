using CodeBase.Components;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
  public class HpBar : MonoBehaviour
  {
    [SerializeField] private Image imageCurrent;
    [SerializeField] private Health health;

    private void Awake() => 
      health.Changed += HealthChanged;

    private void OnDestroy() => 
      health.Changed -= HealthChanged;

    private void HealthChanged() => 
      imageCurrent.fillAmount = health.Current / health.Max;
  }
}