using Sirenix.Serialization;
using UnityEditor;
using UnityEngine;

namespace HeroesVBattle.Data.ReferenceResolvers
{
  public class ScriptableObjectStringReferenceResolver : IExternalStringReferenceResolver
  {
    public IExternalStringReferenceResolver NextResolver { get; set; } 

    public bool CanReference(object value, out string id)
    {
      if (value is ScriptableObject)
      {
        id = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(value as ScriptableObject));
        return true;
      }

      id = null;
      return false;
    }

    public bool TryResolveReference(string id, out object value)
    {
      value = AssetDatabase.LoadAssetAtPath<ScriptableObject>(AssetDatabase.GUIDToAssetPath(id));
      return value != null;
    }
  }
}