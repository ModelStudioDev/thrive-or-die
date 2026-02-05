using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ThriveOrDie.Structures
{
  /// <summary>Holds all relevant data for a structure</summary>
  public class Structure
  {
    #region Data
    /// <summary>The runtime structure stats</summary>
    public StructureStats structureStats;

    private bool isRendered = false;
    #endregion

    #region Constructors
    /// <summary>Creates a new structure from the structureData SO. DO NOT CALL outide of `MapManager`</summary>
    /// <param name="position">The position to spawn the structure in</param>
    /// <param name="structureData">The structure data to use</param>
    public Structure(Vector2Int position, StructureData structureData)
    {
      #region Default constructor
      structureStats = new StructureStats(position, structureData);
      #endregion
    }

    /// <summary>Creates a new structure from the saved structure data. DO NOT CALL outide of `MapManager`</summary>
    /// <param name="structureStats">The structure stats saved data</param>
    public Structure(StructureStats structureStats)
    {
      #region Default constructor
      this.structureStats = structureStats;
      #endregion
    }
    #endregion


    #region Methods
    /// <summary>Gets the current tileBase for this structure</summary>
    /// <returns>The current TileBase to use</returns>
    public TileBase GetTileBase()
    {
      #region GetTileBase
      return structureStats.structureData.sprites.GetValue(structureStats.level);
      #endregion
    }
    #endregion
  }
}
