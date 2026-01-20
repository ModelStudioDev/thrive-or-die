

using UnityEngine;

namespace ThriveOrDie.ResourceSystem
{
  public class ResourceManager : MonoBehaviour
  {
    #region Singleton setup
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
    private Resource woodResource = new Resource(ResourceType.Wood);
    /// <summary>The wood amount</summary>
    public int wood => woodResource.amount;
    /// <summary>The scrap resource</summary>
    [SerializeField]
    private Resource scrapResource = new Resource(ResourceType.Scrap);
    /// <summary>The scrap amount</summary>
    public int scrap => scrapResource.amount;

    [SerializeField]
    /// <summary>The food resource</summary>
    private Resource foodResource = new Resource(ResourceType.Food);
    /// <summary>The food amount</summary>
    public int food => foodResource.amount;

    [SerializeField]
    /// <summary>The water resource</summary>
    private Resource waterResource = new Resource(ResourceType.Water);
    /// <summary>The water amount</summary>
    public int water => waterResource.amount;

    //TODO: Add missing resources
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
