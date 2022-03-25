using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace CodeBase.Logic
{
  public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
  {
    [SerializeField] private CanvasGroup curtain;
    
    private void Awake()
    {
      DontDestroyOnLoad(this);
    }

    public void Show()
    {
      gameObject.SetActive(true);
      curtain.alpha = 1;
    }

    public async Task Hide() =>
      await curtain.DOFade(0, 1).AsyncWaitForCompletion();
    
  }
}