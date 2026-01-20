

using System;
using UnityEngine;

namespace ThriveOrDie.ResourceSystem
{
  [Serializable]
  public record Resource
  {
    #region Data
    [SerializeField] private ResourceType _resourceType;
    [SerializeField] private int _amount = 0;
    /// <summary>The type of this resource</summary>
    public ResourceType resourceType => _resourceType;
    /// <summary>The amount of this resource</summary>
    public int amount => _amount;
    #endregion

    #region Constructor
    public Resource(ResourceType resourceType)
    {
      _resourceType = resourceType;
    }
    #endregion

    #region Methods
    /// <summary>Adds the passed amount to the resource quantity</summary>
    /// <param name="amount">The amount to add</param>
    public void Add(int amount)
    {
      #region Add
      _amount += amount;
      #endregion
    }

    /// <summary>Sets the passed amount as the current resource amount</summary>
    /// <param name="amount">The amount to set</param>
    public void Set(int amount)
    {
      #region Set
      _amount = amount;
      #endregion
    }

    /// <summary>Substracts the passed amount as the current resource amount</summary>
    /// <param name="amount">The amount to substract</param>
    /// <param name="zeroOut">Whether to set to 0 in case of insuficient funds</param>
    /// <returns>Whether it has been subscribed</returns>
    public bool Substract(int amount, bool zeroOut = false)
    {
      #region Substract
      if (this.amount - amount < 0)
      {
        if (zeroOut) { Set(0); return true; }
        return false;
      }
      _amount = amount;
      return true;
      #endregion
    }
    #endregion
  }
}
