using System;
using System.Reflection;
using UnityEngine;

namespace ThriveOrDie.ResourceSystem
{
  public class ResourceManager : MonoBehaviour
  {
    #region Singleton setup
    /// <summary>Singleton instance of ResourceManager</summary>
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
    [SerializeField] private ResourceAmount woodResource = new ResourceAmount(ResourceType.Wood);
    /// <summary>The wood amount</summary>
    public int wood => woodResource.amount;
    /// <summary>The scrap resource</summary>
    [SerializeField] private ResourceAmount scrapResource = new ResourceAmount(ResourceType.Scrap);
    /// <summary>The scrap amount</summary>
    public int scrap => scrapResource.amount;

    /// <summary>The food resource</summary>
    [SerializeField] private ResourceAmount foodResource = new ResourceAmount(ResourceType.Food);
    /// <summary>The food amount</summary>
    public int food => foodResource.amount;

    /// <summary>The water resource</summary>
    [SerializeField] private ResourceAmount waterResource = new ResourceAmount(ResourceType.Water);
    /// <summary>The water amount</summary>
    public int water => waterResource.amount;
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
    /// <summary>Whether there are sufficient funds</summary>
    /// <param name="cost">The cost to check</param>
    /// <returns>Whether there are sufficient funds</returns>
    public static bool HasFunds(Cost cost)
    {
      #region HasFunds
      bool hasFunds = true;
      foreach (ResourceAmount resourceCost in cost.costs)
      {
        ResourceAmount resource = Singleton.GetResourceOfType(resourceCost.resourceType);
        if (resource.amount > resourceCost.amount) continue;
        hasFunds = false;
        break;
      }
      return hasFunds;
      #endregion
    }

    /// <summary>Gets the resource of the requested type</summary>
    /// <param name="resourceType">The type of resource to get</param>
    /// <returns>The found resource record</returns>
    /// <exception cref="Exception">Throws when the resouce is not found</exception>
    private ResourceAmount GetResourceOfType(ResourceType resourceType)
    {
      #region GetResourceOfType
      FieldInfo[] fields = GetType().GetFields();
      foreach (FieldInfo field in fields)
      {
        if (field.GetType() != typeof(ResourceAmount)) continue;
        if (((ResourceAmount)field.GetValue(this)).resourceType == resourceType) return (ResourceAmount)field.GetValue(this);
      }

      throw new Exception($"Can't find resource of type {resourceType}");
      #endregion
    }
    #endregion
  }
}
