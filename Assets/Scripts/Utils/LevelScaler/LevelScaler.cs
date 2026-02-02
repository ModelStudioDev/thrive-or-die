

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

  [Serializable]
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
          try { return Scale(baseValue, multiplyer * currentLevel); }
          catch (Exception ex) { throw new Exception($"Operation failed for scalar: ex {ex.Message}"); }

        default:
          throw new Exception($"Unknown scaling type {scalerType}");
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

    /// <summary>Handles type-safe scalability operations</summary>
    /// <param name="value">The value to scale</param>
    /// <param name="scalar">The current scale factor</param>
    /// <returns>The scaled value</returns>
    /// <exception cref="Exception">Throws if the type is not implemented</exception>
    private DataType Scale(DataType value, float scalar)
    {
      #region Scale
      if (typeof(DataType) == typeof(int))
        return (DataType)(object)((int)(object)value * scalar);

      if (typeof(DataType) == typeof(float))
        return (DataType)(object)((float)(object)value * scalar);

      if (typeof(DataType) == typeof(double))
        return (DataType)(object)((double)(object)value * scalar);

      if (typeof(DataType) == typeof(long))
        return (DataType)(object)((long)(object)value * scalar);

      if (typeof(DataType) == typeof(short))
        return (DataType)(object)(short)((short)(object)value * scalar);

      throw new Exception($"Data type {typeof(DataType).Name} is not implemented");
      #endregion
    }
    #endregion
  }
}
