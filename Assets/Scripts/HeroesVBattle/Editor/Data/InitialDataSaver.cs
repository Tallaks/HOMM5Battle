using System.IO;
using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Data.GameData;
using HeroesVBattle.Data.ReferenceResolvers;
using Sirenix.Serialization;
using UnityEngine;

namespace HeroesVBattle.Editor.Data
{
  public class InitialDataSaver
  {
    private readonly Version _version;
    private readonly ArmyData _playerData;
    private readonly ArmyData _enemyData;

    private string InitDataPath => Application.dataPath + "/Resources/Data/Initial/init.sav";
    
    public InitialDataSaver(Version version, ArmyData playerData, ArmyData enemyData)
    {
      _version = version;
      _playerData = playerData;
      _enemyData = enemyData;
    }

    public void Save()
    {
      var initialData = new InitialData()
      {
        Version = _version,
        PlayerArmy = _playerData,
        EnemyArmy = _enemyData
      };

      var context = new SerializationContext()
      {
        StringReferenceResolver = new ScriptableObjectStringReferenceResolver(),
      };
      
      byte[] bytes = SerializationUtility.SerializeValue<InitialData>(initialData, DataFormat.Binary,context);
      if(!File.Exists(InitDataPath))
      {
        File.Create(InitDataPath);
        File.OpenWrite(InitDataPath);
      }
      File.WriteAllBytes(InitDataPath,bytes);
    }
  }
}