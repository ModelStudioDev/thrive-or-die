
using System;

namespace ThriveOrDie.Utils
{
  /// <summary>Wrapper for a backer propperty with a getter for load on first use</summary>
  public record FieldGetter<FieldType>
  {
    #region Data
    /// <summary>the backer field (Stores the actual data)</summary>
    private FieldType _backer;
    /// <summary>The getter for the data</summary>
    private Func<FieldType, FieldType> getter;
    /// <summary>The underlying value</summary>
    public FieldType value => getter(_backer);
    #endregion

    #region Constructor
    public FieldGetter(Func<FieldType, FieldType> getter)
    {
      this.getter = getter;
    }
    #endregion

    #region Methods
    /// <summary>Force loads the fieldGetter</summary>
    public void ForceLoad()
    {
      #region ForceLoad
      getter(_backer);
      #endregion
    }
    #endregion
  }
}
