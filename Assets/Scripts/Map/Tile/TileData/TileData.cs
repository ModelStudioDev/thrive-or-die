

namespace ThriveOrDie.Map
{
  /// <summary>Contains all the info about a tile</summary>
  public record TileData
  {
    #region Data
    /// <summary>The map tile belonging to this tile</summary>
    public MapTile mapTile = new();

    /// <summary>the tile data relating to the navigation</summary>
    public NavTile navTile = new();

    /// <summary>The tile data relating to the structures</summary>
    public StructureTile structureTile = new();
    #endregion


    #region Aliases
    /// <summary>Sets or REPLACES the current structure of this tile</summary>
    /// <param name="newStructure">The new structure to set</param>
    public void SetStructure(Structure newStructure) => structureTile.SetStructure(newStructure);

    /// <summary>Removes the current structure (if present) from the tile</summary>
    public void RemoveStructure() => structureTile.RemoveStructure();
    #endregion
  }
}
