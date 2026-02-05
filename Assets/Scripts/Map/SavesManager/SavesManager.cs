

using System.IO;
using ThriveOrDie.Structures;
using UnityEngine;

namespace ThriveOrDie.Map
{
  /// <summary>Manages all saving related features</summary>
  public static class SavesManager
  {
    #region Data
    private static string structuresfile => Path.Combine(Application.persistentDataPath, "Structures.json");
    #endregion

    #region Methods
    /// <summary>Loads all structures</summary>
    public static StructureStats[] LoadStructures()
    {
      #region LoadStructures
      // TODO: Read from file
      return new StructureStats[0];
      #endregion
    }

    public static void SaveStrctures(StructureStats[] structures)
    {
      #region LoadStructures
      // TODO: Save to file
      #endregion
    }
    #endregion
  }
}
