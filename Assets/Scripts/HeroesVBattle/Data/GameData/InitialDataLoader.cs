using System.IO;
using HeroesVBattle.Data.ReferenceResolvers;
using Sirenix.Serialization;
using UnityEngine;

namespace HeroesVBattle.Data.GameData
{
  public class InitialDataLoader
  {
    private string InitDataPath => Application.dataPath + "/Resources/Data/Initial/init.sav";

    public InitialData LoadFromFile()
    {
      var context = new DeserializationContext()
      {
        StringReferenceResolver = new ScriptableObjectStringReferenceResolver(),
      };

      byte[] bytes = File.ReadAllBytes(InitDataPath);
      return SerializationUtility.DeserializeValue<InitialData>(bytes,DataFormat.Binary,context);
    }
  }
}