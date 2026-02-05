using ThriveOrDie.Structures;

namespace ThriveOrDie.Map
{
  /// <summary>Data related to the tile structures</summary>
  public record StructureTile
  {
    #region Data
    /// <summary>Whether this tile is ocupied by a structure</summary>
    public bool isOcupiedByStructure => structure != null;
    /// <summary>The structure this tile is ocupied by, if any</summary>
    public Structure structure { get; private set; } = null;
    #endregion

    #region Methods
    /// <summary>Sets or REPLACES the current structure of this tile</summary>
    /// <param name="newStructure">The new structure to set</param>
    public void SetStructure(Structure newStructure)
    {
      #region SetStructure
      structure = newStructure;
      #endregion
    }

    /// <summary>Removes the current structure (if present) from the tile</summary>
    public void RemoveStructure()
    {
      #region RemoveStructure
      structure = null;
      #endregion
    }
    #endregion
  }
}
