

using System;
using System.Collections.Generic;
using UnityEngine;

namespace ThriveOrDie.Utils
{

  [Serializable]
  public record LevelDefined<DataType>
  {
    #region Data
    /// <summary>The defined values per-level</summary>
    [SerializeField] private List<DataType> _values;
    /// <summary>The defined values per-level</summary>
    public List<DataType> values => _values;
    #endregion

    /// <summary>Gets the current value</summary>
    /// <param name="level">The current level to get the value for</param>
    /// <returns>The value for the level</returns>
    public DataType GetValue(short level)
    {
      #region GetValue
      if (level < 0 || level >= _values.Count) throw new Exception($"Can't get value for level. Currentlevel {level} out of range");
      return _values[level];
      #endregion
    }
  }
}
