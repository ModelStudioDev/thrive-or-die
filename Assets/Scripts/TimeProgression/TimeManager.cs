

using System;
using UnityEngine;
using ThriveOrDie.Utils;
using System.Collections.Generic;
using UnityEngine.Rendering;


namespace ThriveOrDie.TimeProgression
{
  /// <summary>Manages all time related aspects</summary>
  public class TimeManager : MonoBehaviour
  {
    #region Singleton setup
    public static TimeManager Singleton;
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
    private FieldGetter<TimeSpan> gameOffset = new(GetGameOffset);

    /// <summary>The current sun weight</summary>
    [SerializeField] private float sunWeight;

    [SerializeField] private float transitionTime;
    private float currentTransitionTime;

    private bool hasTransitioned;
    private bool isTransitioning;
    /// <summary>The last sun weight</summary>
    // [SerializeField] private float prevSunWeight;
    /// <summary>The desired wun weights</summary>
    // [SerializeField] private List<float> sunWeights = new();

    /// <summary>The sun volume</summary>
    [SerializeField] private Volume sun;
    #endregion


    #region Unity
    /// <summary>Called by unity on load</summary>
    private void Awake()
    {
      #region Awake
      SetupSingleton();
      gameOffset.ForceLoad();
      #endregion
    }

    /// <summary>Called by unity each frame</summary>
    private void FixedUpdate()
    {
      #region FixedUpdate
      RunDayNightCicle();

      // if (inGameTime.Hour == 20) // Sunset
      #endregion
    }
    #endregion

    #region Methods
    /// <summary>Runs the day night cicle</summary>
    private void RunDayNightCicle()
    {
      #region RunDayNightCicle
      DateTime inGameTime = GetCurrentTime();
      if (!isTransitioning && (inGameTime.Hour >= 7 || inGameTime.Hour >= 21)) isTransitioning = true;
      if (!hasTransitioned && !isTransitioning) return;
      timeSpeedModifier = 0;
      float prev = inGameTime.Hour <= 7 ? 1 : 0;
      float next = inGameTime.Hour <= 7 ? 0 : 1;

      float lerpTime = currentTransitionTime / transitionTime;
      Debug.Log(lerpTime);

      sunWeight = Mathf.Lerp(prev, next, lerpTime);
      sun.weight = sunWeight;
      if (lerpTime <= 0)
      {
        hasTransitioned = true;
        isTransitioning = false;
        currentTransitionTime = transitionTime;
        timeSpeedModifier = 40;
      }
      #endregion
    }

    /// <summary>Gets the scaled in-game time</summary>
    public DateTime GetCurrentTime()
    {
      #region GetCurrentTime
      TimeSpan timeElapsed = DateTime.Now - startTime;
      double scaledSeconds = timeElapsed.TotalSeconds * timeSpeed * timeSpeedModifier;
      return startTime + TimeSpan.FromSeconds(scaledSeconds) + gameOffset.value;
      #endregion
    }

    private static TimeSpan GetGameOffset(TimeSpan _backer)
    {
      #region GetGameOffset
      if (_backer != null) return _backer;

      // TODO: Get from file

      //TEMP
      return TimeSpan.Zero;
      #endregion
    }
    #endregion
  }
}
