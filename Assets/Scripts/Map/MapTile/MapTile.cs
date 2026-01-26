

using UnityEngine.Tilemaps;

namespace ThriveOrDie.Map
{
  /// <summary>Contains the data of a tile</summary>
  public record MapTile
  {
    #region Data
    /// <summary>The `TileBase` assset (Sprite) of this tile</summary>
    private TileBase _tileBase;
    /// <summary>The `TileBase` assset (Sprite) of this tile</summary>
    public TileBase tileBase => _tileBase;
    #endregion

    #region Constructor
    /// <summary>Creates a new tile with default values</summary>
    public MapTile() { }
    /// <summary>Creates a new tile with the passed tileBase</summary>
    /// <param name="tileBase">The tileBase to set</param>
    public MapTile(TileBase tileBase) { _tileBase = tileBase; }
    #endregion

    #region Methods
    /// <summary>Sets this tile base asset</summary>
    /// <param name="newTileBase">The new tile base</param>
    public void SetTileBase(TileBase newTileBase)
    {
      #region SetTileBase
      _tileBase = newTileBase;
      #endregion
    }
    #endregion
  }
}
