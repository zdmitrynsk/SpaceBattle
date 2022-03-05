using System.Threading.Tasks;

namespace CodeBase.Logic
{
  public interface ILoadingCurtain
  {
    void Show();
    Task Hide();
  }
}