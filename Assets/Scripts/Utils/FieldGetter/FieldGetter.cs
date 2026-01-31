
using System;

namespace ThriveOrDie.Utils
{
  /// <summary>Wrapper for a backer propperty with a getter for load on first use</summary>
  public record FieldGetter<FieldType>
  {
    #region Data
    /// <summary>Whether the field is loaded</summary>
    public bool isLoaded { get; private set; }
    /// <summary>the backer field (Stores the actual data)</summary>
    private FieldType _backer;
    /// <summary>The getter for the data</summary>
    private Func<FieldType, bool, FieldType> getter;
    /// <summary>The underlying value</summary>
    public FieldType value
    {
      get
      {
        try
        {
          return getter(_backer, isLoaded);
        }
        finally
        {
          if (!isLoaded) isLoaded = true;
        }
      }
    }
    #endregion

    #region Constructor
    public FieldGetter(Func<FieldType, bool, FieldType> getter)
    {
      this.getter = getter;
    }
    #endregion

    #region Methods
    /// <summary>Force loads the fieldGetter</summary>
    public void ForceLoad()
    {
      #region ForceLoad
      getter(_backer, isLoaded);
      if (!isLoaded) isLoaded = true;
      #endregion
    }

    /// <summary>Force sets the backer value</summary>
    /// <param name="newValue">The new value to set</param>
    public void Set(FieldType newValue)
    {
      #region Set
      _backer = newValue;
      if (!isLoaded) isLoaded = true;
      #endregion
    }
    #endregion
  }
}
