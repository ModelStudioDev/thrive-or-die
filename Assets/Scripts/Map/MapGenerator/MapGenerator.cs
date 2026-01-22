using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ThriveOrDie.Map
{
  public class MapGenerator : MonoBehaviour
  {

    #region Data
    /// <summary>The ground base tiles</summary>
    [SerializeField]
    private TileBase[] groundTiles;

    /// <summary>The ground tilemap</summary>
    [SerializeField]
    private Tilemap groundTilemap;

    /// <summary>The size of the map</summary>
    [SerializeField]
    private int _mapSize;
    /// <summary>The size of the map</summary>
    public int mapSize => _mapSize;

    /// <summary>The modifyable map of tiles</summary>
    private List<List<Map.TileData>> _groundMap;

    /// <summary>READ-ONLY copy of the map</summary>
    public IReadOnlyList<IReadOnlyList<Map.TileData>> groundMap => GetGroundMap();
    #endregion

    #region Unity
    /// <summary>Run by unity</summary>
    private void Start()
    {
      #region Start
      // TODO: THIS SHOULD NOT BE CALLED FROM HERE BUT FROM THE SAVES IF NOT PRESENT!
      PopulateMap();
      #endregion
    }
    #endregion


    #region Methods
    /// <summary>Populates the map</summary>
    public void PopulateMap()
    {
      #region PopulateMap
      for (int row = 0; row < _mapSize; row++)
      {
        for (int col = 0; col < _mapSize; col++)
        {
          TileBase tileBase = GetTile(row, col);
          _groundMap[row][col] = new TileData(tileBase);
          groundTilemap.SetTile(new Vector3Int(row, col), tileBase);
        }
      }
      #endregion
    }

    /// <summary>Gets a copy of the map as read-only</summary>
    private IReadOnlyList<IReadOnlyList<TileData>> GetGroundMap()
    {
      #region GetGroundMap
      return _groundMap.Select(row => row.ToArray()).ToArray();
      #endregion
    }


    /// <summary>Gets a tile base for the passed coordenates</summary>
    /// <param name="row">The row of the tile</param>
    /// <param name="col">The col of the tile</param>
    /// <returns>The tile base asset for the coorrdenates</returns>
    private TileBase GetTile(int row, int col)
    {
      #region GetTile
      // TODO: Generate depending on coordenates

      return groundTiles[Random.Range(0, groundTiles.Length)];
      #endregion
    }
    #endregion
  }
}
