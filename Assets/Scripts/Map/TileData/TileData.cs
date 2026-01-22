

using UnityEngine.Tilemaps;

namespace ThriveOrDie.Map
{
  /// <summary>Contains the data of a tile</summary>
  public record TileData
  {
    #region Data
    /// <summary>Whether this tile is buildable</summary>
    /// <remarks> Default value: TRUE </remarks>
    public bool isBuildable { get; private set; } = true;
    /// <summary>The `TileBase` assset (Sprite) of this tile</summary>
    public TileBase tileBase;
    #endregion

    #region Constructor
    /// <summary>Creates a new tile with default values</summary>
    public TileData() { }
    /// <summary>Creates a new tile with the buildable state as passed</summary>
    /// <param name="buildable">Whether the tile is buildable</param>
    public TileData(bool buildable) { isBuildable = buildable; }
    #endregion

    #region Methods
    /// <summary>Sets this tile buildable state.</summary>
    /// <param name="buildable"></param>
    public void SetIsBuildableTo(bool buildable)
    {
      #region SetIsBuildableTo
      isBuildable = buildable;
      #endregion
    }
    #endregion
  }
}
