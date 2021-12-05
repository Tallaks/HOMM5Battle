using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Data.GameData;
using HeroesVBattle.Editor.Data;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace HeroesVBattle.Editor.Windows
{
  public class InitialDataSaverWindow : OdinEditorWindow
  {
    [MenuItem("Data/Initial")]
    private static void OpenWindow() => 
      GetWindow<InitialDataSaverWindow>().Show();

    private Config InitialConfig => Resources.Load<Config>("Data/Initial/InitialConfig");
    
    [TitleGroup("Version")]
    [ShowInInspector]
    [PropertyOrder(0f)]
    public Version Version => InitialConfig.InitialDataVersion;
    
    [BoxGroup(GroupName = "Player")]
    [ShowInInspector]
    [PropertyOrder(1f)]
    public ArmyData PlayerData => InitialConfig.Player;
    
    [BoxGroup(GroupName = "Enemy")]
    [ShowInInspector]
    [PropertyOrder(1f)]
    public ArmyData EnemyData => InitialConfig.Enemy;

    [Button("Save Initial Data")]
    [PropertyOrder(2f)]
    private void SaveInitialData()
    {
      var saver = new InitialDataSaver(Version, PlayerData, EnemyData);
      saver.Save();
    }
  }
}