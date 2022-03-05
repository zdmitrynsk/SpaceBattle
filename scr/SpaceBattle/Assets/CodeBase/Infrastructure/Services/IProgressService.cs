using CodeBase.Data;

namespace CodeBase.Infrastructure.Services
{
  public interface IProgressService
  {
    PlayerProgress Progress { get; set; }
  }
}