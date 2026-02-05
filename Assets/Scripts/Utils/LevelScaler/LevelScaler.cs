

using System;
using System.Collections.Generic;

namespace ThriveOrDie.Utils
{
  [Serializable]
  /// <summary>A helper to define a value based on a level</summary>
  public record LevelScaler
  {
    #region Data
    /// <summary>The static value of this stat</summary>
    private float _baseValue;
    /// <summary>The static value of this stat</summary>
    public float baseValue => _baseValue;


    /// <summary>The defined values per-level</summary>
    private List<float> _definedValues;
    /// <summary>The defined values per-level</summary>
    public List<float> definedValues => _definedValues;

    /// <summary>The multiplyer for the per-level grouth</summary>
    private float _multiplyer;
    /// <summary>The multiplyer for the per-level grouth</summary>
    public float multiplyer => _multiplyer;

    /// <summary>The max amount of levels</summary>
    private int _maxLevels;
    /// <summary>The max amount of levels</summary>
    public int maxLevels => _maxLevels;

    /// <summary>The type of sclability to use</summary>
    private ScalerType _scalerType;
    /// <summary>The type of sclability to use</summary>
    public ScalerType scalerType => _scalerType;
    #endregion

    #region Methods
    /// <summary>Gets the current value</summary>
    /// <param name="level">The current level to get the value for. Not set for static</param>
    /// <returns>The scaled value</returns>
    /// <exception cref="Exception">Throws if the operation is invalid</exception>
    public float GetValue(short level = -1)
    {
      #region GetValue
      switch (scalerType)
      {
        case ScalerType.Static:
          return GetStaticValue();

        case ScalerType.Defined:
          return GetDefinedValue(level);

        case ScalerType.Scaled:
          return GetScaledValue(level);

        default:
          throw new Exception($"Unknown scaling type {scalerType}");
      }

      #endregion
    }

    /// <summary>Gets the static value of this scalar</summary>
    /// <returns>The base value</returns>
    private float GetStaticValue() => baseValue;

    /// <summary>Gets the pre-defined value</summary>
    /// <param name="level">The level to get the value for</param>
    /// <returns>The found value for the requested level</returns>
    /// <exception cref="Exception">Throws if level was not provided or is out of range</exception>
    private float GetDefinedValue(short level)
    {
      #region GetDefinedValue
      if (level == -1) throw new Exception("Can't get defined value with no currentLevel");
      if (level < 0 || level >= _definedValues.Count) throw new Exception($"Can't get defined value. Currentlevel {level} out of range");

      return _definedValues[level];
      #endregion
    }

    /// <summary>Gets the scaled value based on level</summary>
    /// <param name="level">Thje level to get the value for</param>
    /// <returns>The scaled value</returns>
    /// <exception cref="Exception">Throws if no level was provided</exception>
    private float GetScaledValue(short level)
    {
      #region GetScaledValue
      if (level == -1) throw new Exception("Can't get scaled value with no currentLevel");

      return baseValue * (multiplyer * level);
      #endregion
    }
    #endregion
  }
}
