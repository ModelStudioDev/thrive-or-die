

namespace ThriveOrDie.Map
{
  /// <summary>Contains all the info about a tile</summary>
  public record TileData
  {
    #region Data
    /// <summary>Whether this tile can be built on</summary>
    public bool isBuildable;
    /// <summary>Whether this tile is currently ocupied</summary>
    public bool isOcupied;

    /// <summary>The map tile belonging to this tile</summary>
    public MapTile mapTile;

    #endregion
  }
}
