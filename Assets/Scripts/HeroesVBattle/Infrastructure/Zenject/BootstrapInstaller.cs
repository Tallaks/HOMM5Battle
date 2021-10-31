using Zenject;

namespace HeroesVBattle.Infrastructure.Zenject
{
  public class BootstrapInstaller : MonoInstaller
  {
    private const string BootstrapperPath = "Infrastructure/Bootstrapper";

    public override void InstallBindings()
    {
      Container.
        Bind<CoroutineRunner>().
        FromMethod(FindObjectOfType<CoroutineRunner>).
        AsSingle();

      Container.
        Bind<ICoroutineRunner>().
        To<CoroutineRunner>().
        FromResolve();
      
      Container.
        Bind<SceneLoader>().
        FromNew().
        AsSingle();
      
      var bootstrapper = Container.
        InstantiatePrefabResourceForComponent<Bootstrapper>(BootstrapperPath);

      Container.
        Bind<Bootstrapper>().
        FromInstance(bootstrapper).
        AsSingle();
    }
  }
}