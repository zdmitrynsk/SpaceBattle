using System.Threading.Tasks;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
  public interface IUIFactory : IService
  {
    Task CreateUIRoot();
    Task<GameObject> CreateGameOverWindow();
    Task<GameObject> CreateTitleLevel(int levelDifficult);
  }
}