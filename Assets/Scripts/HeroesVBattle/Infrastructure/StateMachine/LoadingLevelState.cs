namespace HeroesVBattle.Infrastructure.StateMachine
{
  public class LoadingLevelState : IState
  {
    private const string Main = "Main";
    
    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public LoadingLevelState(StateMachine stateMachine, SceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }

    public void Enter() => 
      LoadMainScene();

    public void Exit()
    {
    }

    private void LoadMainScene() => 
      _sceneLoader.Load(Main);
  }
}