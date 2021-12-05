using System.IO;
using HeroesVBattle.Data.EditorData;
using HeroesVBattle.Data.ReferenceResolvers;
using Sirenix.Serialization;
using UnityEngine;

namespace HeroesVBattle.Data.GameData
{
  public class InitialDataLoader
  {
    private string InitDataPath => Application.dataPath + "/Resources/Data/Initial/init.sav";
    private Config Config => Resources.Load<Config>("Data/Initial/InitialConfig");

    public bool LoadFromFile(out InitialData data)
    {
      var context = new DeserializationContext()
      {
        StringReferenceResolver = new ScriptableObjectStringReferenceResolver(),
      };

      byte[] bytes = File.ReadAllBytes(InitDataPath);
      data = SerializationUtility.DeserializeValue<InitialData>(bytes,DataFormat.Binary,context);

      return data.Version == Config.InitialDataVersion;
    }
  }
}