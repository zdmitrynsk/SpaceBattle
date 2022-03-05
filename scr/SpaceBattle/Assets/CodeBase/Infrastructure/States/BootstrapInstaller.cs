using Zenject;

namespace CodeBase.Infrastructure.States
{
  public class BootstrapInstaller : Installer<BootstrapInstaller>
  {
    private IGameStateMachine _stateMachine;

    public BootstrapInstaller(IGameStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }

    public override void InstallBindings()
    {

    }
    

  }
}