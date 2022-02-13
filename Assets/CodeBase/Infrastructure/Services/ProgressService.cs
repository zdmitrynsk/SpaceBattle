using CodeBase.Data;

namespace CodeBase.Infrastructure.Services
{
  class ProgressService : IProgressService
  {
    public PlayerProgress Progress { get; set; }

    public ProgressService()
    {
      Progress = new PlayerProgress();
    }
  }
}