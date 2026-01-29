

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
    /// <summary>The PERSISTENT game time</summary>
    private readonly FieldGetter<DateTime> inGameTime = new(GetGameTime);

    /// <summary>The current sun weight</summary>
    [SerializeField] private float sunWeight;
    /// <summary>The transition time in IN-GAME minutes</summary>
    [SerializeField] private float transitionTime;

    private readonly TimeSpan sunrise = new(8, 0, 0);
    private readonly TimeSpan sunset = new(20, 0, 0);
    private float transitionProgress;

    [SerializeField] private bool isTransitioning;


    /// <summary>The sun volume</summary>
    [SerializeField] private Volume sun;
    #endregion


    #region Unity
    /// <summary>Called by unity on load</summary>
    private void Awake()
    {
      #region Awake
      SetupSingleton();
      inGameTime.ForceLoad();
      InvokeRepeating("log", 0, 1);
      #endregion
    }

    /// <summary>Lore</summary>
    private void log()
    {
      #region NetMethod
      Debug.Log(inGameTime.value);
      #endregion
    }

    /// <summary>Called by unity each frame</summary>
    private void FixedUpdate()
    {
      #region FixedUpdate
      RunTime();
      RunDayNightCicle();

      // if (inGameTime.Hour == 20) // Sunset
      #endregion
    }
    #endregion

    #region Methods
    /// <summary>Runs the in-Game time</summary>
    private void RunTime()
    {
      #region RunTime
      float timeToAdd = timeSpeed * timeSpeedModifier * Time.fixedDeltaTime;
      // Debug.Log(timeToAdd);
      inGameTime.Set(inGameTime.value.AddSeconds(timeToAdd));
      #endregion
    }

    /// <summary>Runs the day night cicle</summary>
    private void RunDayNightCicle()
    {
      #region RunDayNightCicle
      if ((HasTimeSpanPassedThisFrame(sunrise) || HasTimeSpanPassedThisFrame(sunset)) && !isTransitioning) isTransitioning = true;
      if (!isTransitioning) return;

      timeSpeedModifier = 1;
      bool isDay = inGameTime.value.TimeOfDay >= sunrise && inGameTime.value.TimeOfDay < sunset;
      float prev = isDay ? 1 : 0;
      float next = isDay ? 0 : 1;

      float transitionSeconds = transitionTime * 60 / (timeSpeed * timeSpeedModifier);

      transitionProgress += Time.fixedDeltaTime / transitionSeconds;
      transitionProgress = Mathf.Clamp01(transitionProgress);
      sunWeight = Mathf.Lerp(prev, next, transitionProgress);

      sun.weight = sunWeight;
      if (transitionProgress >= 1)
      {
        transitionProgress = 0f;
        timeSpeedModifier = 40;
        isTransitioning = false;
      }
      #endregion
    }

    /// <summary>Lore</summary>
    private bool HasTimeSpanPassedThisFrame(TimeSpan timeSpan)
    {
      #region HasTimeStampPassedThisFrame
      float timeToRemove = timeSpeed * timeSpeedModifier * Time.fixedDeltaTime;
      TimeSpan prevSpan = GetCurrentTime().TimeOfDay - TimeSpan.FromSeconds(timeToRemove);
      TimeSpan currentSpan = GetCurrentTime().TimeOfDay;
      return timeSpan >= prevSpan && timeSpan <= currentSpan;
      #endregion
    }

    /// <summary>Gets the scaled in-game time</summary>
    public DateTime GetCurrentTime()
    {
      #region GetCurrentTime
      return inGameTime.value;
      #endregion
    }

    private static DateTime GetGameTime(DateTime _backer)
    {
      #region GetGameOffset
      if (_backer != null) return _backer;

      // TODO: Get from file

      //TEMP
      return DateTime.Now;
      #endregion
    }
    #endregion
  }
}
