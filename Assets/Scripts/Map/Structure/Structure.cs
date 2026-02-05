using System;
using ThriveOrDie.Structures;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ThriveOrDie.Map
{
  /// <summary>Holds all relevant data for a structure</summary>
  public class Structure : MonoBehaviour
  {
    #region Data
    /// <summary>The structure data</summary>
    public StructureData structureData;
    /// <summary>The runtime structure stats</summary>
    public StructureStats structureStats;
    #endregion


    #region Methods
    /// <summary>Initializes the structure at it's position. DO NOT CALL outide of `MapManager`</summary>
    /// <param name="position">The grid position</param>
    public void Initialize(Vector2Int position)
    {
      #region Initialize
      structureStats = new StructureStats(position, structureData);
      #endregion
    }

    /// <summary>Gets the current tileBase for this structure</summary>
    /// <returns>The current TileBase to use</returns>
    public TileBase GetTileBase()
    {
      #region GetTileBase
      throw new NotImplementedException();
      #endregion
    }
    #endregion
  }
}
