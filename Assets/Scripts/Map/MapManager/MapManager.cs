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
