

using System;
using UnityEngine;

namespace ThriveOrDie.Time
{
  /// <summary>Manages all time related aspects</summary>
  public class TimeManager : MonoBehaviour
  {
    #region Singleton setup
    public TimeManager Singleton;
    /// <summary>Sets up the singleton instace</summary>
    private void SetupSingleton()
    {
      #region SetupSingleton
      if (!!Singleton && Singleton != this) { Destroy(this); return; }
      Singleton = this;
      #endregion
    }
    #endregion


    #region Data
    /// <summary>The base time speed of the game</summary>
    [SerializeField] readonly float timeSpeed = 72f;

    /// <summary>A day duration in seconds</summary>
    [SerializeField] private readonly float dayDuration = 3600 * 24;
    /// <summary>The current speed modifier</summary>
    [SerializeField] private float timeSpeedModifier = 1f;
    /// <summary>The REAL start time</summary>
    private DateTime startTime = DateTime.Now;
    /// <summary>The PERSISTENT game offset</summary>
    // private TimeSpan gameOffset = 
    #endregion


    #region Unity
    /// <summary>Called by unity on load</summary>
    private void Awake()
    {
      #region Awake
      SetupSingleton();
      #endregion
    }

    /// <summary>Called by unity each frame</summary>
    private void FixedUpdate()
    {
      #region FixedUpdate
      #endregion
    }
    #endregion

    #region Methods
    /// <summary>Lore</summary>
    public DateTime GetCurrentTime()
    {
      #region GetCurrentTime
      TimeSpan timeElapsed = DateTime.Now - startTime;
      double scaledSeconds = timeElapsed.TotalSeconds * timeSpeed * timeSpeedModifier;
      return startTime + TimeSpan.FromSeconds(scaledSeconds) + gameOffset;
      #endregion
    }
    #endregion
  }
}
