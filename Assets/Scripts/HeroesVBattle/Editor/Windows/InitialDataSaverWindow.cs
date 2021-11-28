using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Data.GameData;
using HeroesVBattle.Editor.Data;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace HeroesVBattle.Editor.Windows
{
  public class InitialDataSaverWindow : OdinEditorWindow
  {
    [MenuItem("Data/Initial")]
    private static void OpenWindow() => 
      GetWindow<InitialDataSaverWindow>().Show();

    [TitleGroup("Version")]
    public Version Version;
    
    [BoxGroup(GroupName = "Player")]
    public ArmyData PlayerData;
    
    [BoxGroup(GroupName = "Enemy")]
    public ArmyData EnemyData;

    [Button("Save Initial Data")]
    private void SaveInitialData()
    {
      var saver = new InitialDataSaver(Version, PlayerData, EnemyData);
      saver.Save();
    }
  }
}