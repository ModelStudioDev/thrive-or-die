

using System;
using UnityEngine;
using ThriveOrDie.Utils;
using UnityEngine.Rendering;
using System.IO;


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
    /// <summary>The settings file path</summary>
    private static string timePath => Path.Combine(Application.persistentDataPath, "Time");
    /// <summary>The default start time January 1st 2035 @ 10:00:00</summary>
    private static DateTime defaultTimeStart = new DateTime(2035, 1, 1, 10, 0, 0);

    /// <summary>The base time speed of the game</summary>
    private const float TimeSpeed = 72f;
    /// <summary>The current speed modifier</summary>
    [SerializeField] private float timeSpeedModifier = 1f;
    /// <summary>The PERSISTENT game time</summary>
    private readonly FieldGetter<DateTime> inGameTime = new(GetGameTime);

    /// <summary>The current sun weight</summary>
    private float sunWeight;
    /// <summary>The sun volume</summary>
    [SerializeField] private Volume sun;

    /// <summary>The transition time in IN-GAME minutes</summary>
    private float transitionTime;
    /// <summary>The current transition progress</summary>
    private float transitionProgress;
    /// <summary>Whether the sun is chaning states right now</summary>
    private bool isTransitioning;

    /// <summary>The time at wich the sun rises</summary>
    private readonly TimeSpan sunrise = new(8, 0, 0);
    /// <summary>The time at wich the sun sets</summary>
    private readonly TimeSpan sunset = new(20, 0, 0);
    #endregion

    #region Unity
    /// <summary>Called by unity on load</summary>
    private void Awake()
    {
      #region Awake
      SetupSingleton();
      inGameTime.ForceLoad();
      #endregion
    }


    /// <summary>Called by unity each frame</summary>
    private void FixedUpdate()
    {
      #region FixedUpdate
      RunTime();
      #endregion
    }
    #endregion

    #region Methods
    #region Static
    /// <summary>Checks whether a specific time has pased in this frame</summary>
    /// <param name="timeSpan">The time "stamp" to check</param>
    /// <returns>Whether it has passed or not</returns>
    private static bool HasTimeSpanPassedThisFrame(TimeSpan timeSpan)
    {
      #region HasTimeStampPassedThisFrame
      float timeToRemove = TimeSpeed * Singleton.timeSpeedModifier * Time.fixedDeltaTime;
      TimeSpan prevSpan = GetCurrentTime().TimeOfDay - TimeSpan.FromSeconds(timeToRemove);
      TimeSpan currentSpan = GetCurrentTime().TimeOfDay;
      return timeSpan >= prevSpan && timeSpan <= currentSpan;
      #endregion
    }

    /// <summary>Gets the scaled in-game time</summary>
    /// <returns>The current in-game DateTime</returns>
    public static DateTime GetCurrentTime()
    {
      #region GetCurrentTime
      return Singleton.inGameTime.value;
      #endregion
    }

    /// <summary>Getter for the inGameTime field getter</summary>
    /// <param name="_backer">The field backer</param>
    /// <returns>The inGameTime value</returns>
    private static DateTime GetGameTime(DateTime _backer, bool isLoaded)
    {
      #region GetGameOffset
      if (isLoaded) return _backer;

      if (!File.Exists(timePath)) { SaveTime(defaultTimeStart); return defaultTimeStart; }

      long ticks = long.Parse(File.ReadAllText(timePath));
      return new DateTime(ticks);
      #endregion
    }

    /// <summary>Saves the current inGameTime to file</summary>
    private static void SaveTime(DateTime timeToSave)
    {
      #region SaveTime
      File.WriteAllText(timePath, timeToSave.Ticks.ToString());
      #endregion
    }
    #endregion

    #region Instance
    /// <summary>Runs the in-Game time</summary>
    private void RunTime()
    {
      #region RunTime
      float timeToAdd = TimeSpeed * timeSpeedModifier * Time.fixedDeltaTime;
      inGameTime.Set(inGameTime.value.AddSeconds(timeToAdd));

      if (ShouldRunTranstion()) RunTransition();
      #endregion
    }

    #region Day/Night Transition
    /// <summary>Checks whether the day/night transition should run</summary>
    /// <returns>Whether it should run</returns>
    private bool ShouldRunTranstion()
    {
      #region ShouldRunTranstion
      return isTransitioning || HasTimeSpanPassedThisFrame(sunrise) || HasTimeSpanPassedThisFrame(sunset);
      #endregion
    }

    /// <summary>Runs the day/night transition</summary>
    private void RunTransition()
    {
      #region RunTransition
      if (!isTransitioning) isTransitioning = true;

      bool isDay = inGameTime.value.TimeOfDay >= sunrise && inGameTime.value.TimeOfDay < sunset;
      float prev = isDay ? 1 : 0;
      float next = isDay ? 0 : 1;

      float transitionSeconds = transitionTime * 60 / (TimeSpeed * timeSpeedModifier);

      transitionProgress += Time.fixedDeltaTime / transitionSeconds;
      transitionProgress = Mathf.Clamp01(transitionProgress);
      sunWeight = Mathf.Lerp(prev, next, transitionProgress);

      sun.weight = sunWeight;
      if (transitionProgress != 1) return;
      EndTransition();
      #endregion
    }

    /// <summary>Ends the day/night transition</summary>
    private void EndTransition()
    {
      #region EndTransition
      transitionProgress = 0f;
      isTransitioning = false;
      #endregion
    }
    #endregion
    #endregion
    #endregion
  }
}
