

using UnityEngine;

namespace ThriveOrDie.ResourceSystem
{
  public class ResourceManager : MonoBehaviour
  {
    #region SingletonSetup
    public static ResourceManager Singleton;

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
    /// <summary>The wood resource</summary>
    [SerializeField]
    private Resource wood = new Resource(ResourceType.Wood);
    /// <summary>The scrap resource</summary>
    [SerializeField]
    private Resource scrap = new Resource(ResourceType.Scrap);
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

    #region Methods

    #endregion
  }
}
