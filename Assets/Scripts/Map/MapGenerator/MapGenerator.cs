using System.Collections.Generic;
using System.Linq;
using ThriveOrDie.Utils;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ThriveOrDie.Map
{
  /// <summary>Generates the map tiles</summary>
  public static class MapGenerator
  {
    #region Data
    /// <summary>Getter for the map generator data. if not already loaded it loads it</summary>
    private static FieldGetter<MapGeneratorData> mapGeneratorData = new(GetMapGenerationData);

    /// <summary>The modifyable map of tiles</summary>
    private static List<List<MapTile>> _groundMap = new List<List<MapTile>>();

    /// <summary>READ-ONLY copy of the map</summary>
    public static IReadOnlyList<IReadOnlyList<MapTile>> groundMap => GetGroundMap();
    #endregion

    #region Methods
    /// <summary>Populates the map</summary>
    public static void PopulateMap()
    {
      #region PopulateMap
      int half = _mapSize / 2;
      for (int row = 0; row < _mapSize; row++)
      {
        _groundMap.Add(new List<MapTile>());
        for (int col = 0; col < _mapSize; col++)
        {
          Vector2Int position = new Vector2Int(row - half, col - half);

          TileBase tileBase = GetTile(position);
          _groundMap[row].Add(new MapTile(tileBase));

          groundTilemap.SetTile((Vector3Int)position, tileBase);
        }
      }
      #endregion
    }

    /// <summary>Gets a copy of the map as read-only</summary>
    /// <returns>The read-only copy of the ground</returns>
    private static IReadOnlyList<IReadOnlyList<MapTile>> GetGroundMap()
    {
      #region GetGroundMap
      return _groundMap.Select(row => row.ToArray()).ToArray();
      #endregion
    }

    /// <summary>Gets a tile base for the passed coordenates</summary>
    /// <param name="position">The position of the tile</param>
    /// <returns>The tile base asset for the coorrdenates</returns>
    private static TileBase GetTile(Vector2Int position)
    {
      #region GetTile
      return position.x % 2 == 0 ? mapGeneratorData.groundTiles[0] : mapGeneratorData.groundTiles[1];
      #endregion
    }

    /// <summary>Getter for the map generator data. if not already loaded it loads it</summary>
    /// <returns>The loaded map generation data</returns>
    private static MapGeneratorData GetMapGenerationData(MapGeneratorData _backer)
    {
      #region GetMapGenerationData
      if (_backer == null)
        _backer = Resources.Load<MapGeneratorData>("MapGenerationData");

      return _backer;
      #endregion
    }
    #endregion
  }
}
