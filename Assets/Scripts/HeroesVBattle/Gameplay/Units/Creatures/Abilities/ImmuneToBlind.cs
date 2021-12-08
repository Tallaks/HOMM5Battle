namespace HeroesVBattle.Gameplay.Units.Creatures.Abilities
{
  public class ImmuneToBlind : IAbility
  {
    public void Execute() => 
      IgnoreBlind();

    private void IgnoreBlind()
    {
    }
  }
}