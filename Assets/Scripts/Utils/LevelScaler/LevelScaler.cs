

using System;
using System.Collections.Generic;

namespace ThriveOrDie.Utils
{
  public enum ScalerType
  {
    Static,
    Defined,
    Scaled
  }


  public record LevelScaler<DataType>
  {
    #region Data
    /// <summary>The static value of this stat</summary>
    public DataType baseValue;
    /// <summary>The defined values per-level</summary>
    public List<DataType> definedValues;
    /// <summary>The multiplyer for the per-level grouth</summary>
    public float multiplyer;
    /// <summary>The max amount of levels</summary>
    public int maxLevels;
    /// <summary>The type of sclability to use</summary>
    public ScalerType scalerType;
    #endregion

    #region Methods
    /// <summary>Gets the current value</summary>
    /// <param name="currentLevel">The current level to get the value for. Not set for static</param>
    /// <returns>The scaled value</returns>
    /// <exception cref="Exception">Throws if the operation is invalid</exception>
    public DataType GetValue(short currentLevel = -1)
    {
      #region GetValue
      switch (scalerType)
      {
        case ScalerType.Static:
          return baseValue;

        case ScalerType.Defined:
          if (currentLevel == -1) throw new Exception("Can't get defined value with no currentLevel");
          return definedValues[currentLevel];

        case ScalerType.Scaled:
          if (currentLevel == -1) throw new Exception("Can't get scaled value with no currentLevel");
          if (!IsNumber(typeof(DataType))) throw new Exception("Can't set scalar on non-number type");
          try { return (dynamic)baseValue * (multiplyer * currentLevel); }
          catch (Exception ex) { throw new Exception($"Operation failed for scalar: ex {ex.Message}"); }

        default:
          throw new System.Exception($"Unknown scaling type {scalerType}");
      }

      #endregion
    }

    /// <summary>Checks whether the type is a valid numeric</summary>
    /// <param name="type">The type to check</param>
    /// <returns>Whether it's a valid numeric</returns>
    static bool IsNumber(Type type)
    {
      #region IsNumber
      return type == typeof(byte) ||
           type == typeof(short) ||
           type == typeof(int) ||
           type == typeof(long) ||
           type == typeof(float) ||
           type == typeof(double) ||
           type == typeof(decimal);
      #endregion
    }
    #endregion
  }
}
