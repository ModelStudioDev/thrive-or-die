using System.Collections.Generic;
using UnityEngine;


namespace ThriveOrDie.Map
{
  public class MapManager : MonoBehaviour
  {
    #region Singleton setup
    /// <summary>Singleton instance of MapManager</summary>
    public static MapManager Singleton;

    /// <summary>Sets up the singleton</summary>
    private void SetupSingleton()
    {
      #region SetupSingleton
      if (Singleton != null && Singleton != this) { Destroy(gameObject); return; }
      if (Singleton != this) Singleton = this;
      #endregion
    }
    #endregion

    #region Data
    /// <summary>Store of the tile data</summary>
    public List<List<TileData>> tiles = new();
    /// <summary>Store of all present structures</summary>
    public List<Structure> structures = new();
    #endregion

    #region Unity
    /// <summary>Called by unity on awake</summary>
    private void Awake()
    {
      #region Awake
      SetupSingleton();
      #endregion
    }
    #endregion

  }
}
