using HeroesVBattle.Infrastructure.StateMachine;
using Zenject;

namespace HeroesVBattle.Infrastructure.Zenject
{
  public class BootstrapInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      var stateMachine = new StateMachine.StateMachine(Container);
      stateMachine.Enter<BootstrapState>();
    }
  }
}