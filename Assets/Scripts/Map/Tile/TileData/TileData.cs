

namespace ThriveOrDie.Map
{
  /// <summary>Contains all the info about a tile</summary>
  public record TileData
  {
    #region Data
    /// <summary>The map tile belonging to this tile</summary>
    public MapTile mapTile;

    /// <summary>the tile data relating to the navigation</summary>
    public NavTile navTile;

    /// <summary>The tile data relating to the structures</summary>
    public StructureTile structureTile;
    #endregion
  }
}
