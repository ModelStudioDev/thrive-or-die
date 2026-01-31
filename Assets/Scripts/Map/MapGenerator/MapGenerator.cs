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
    /// <summary>Getter for the map genneration data</summary>
    private static FieldGetter<MapGeneratorData> mapGeneratorData = new(GetMapGenerationData);
    /// <summary>Getter for the ground map</summary>
    private static FieldGetter<Tilemap> groundTilemap = new(GetTileMap);

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
      int mapSize = mapGeneratorData.value.mapSize;
      int half = mapSize / 2;
      for (int row = 0; row < mapSize; row++)
      {
        _groundMap.Add(new List<MapTile>());
        for (int col = 0; col < mapSize; col++)
        {
          Vector2Int position = new Vector2Int(row - half, col - half);

          TileBase tileBase = GetTile(position);
          _groundMap[row].Add(new MapTile(tileBase));

          groundTilemap.value.SetTile((Vector3Int)position, tileBase);
        }
      }
      groundTilemap.value.CompressBounds();
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
      bool isDark = (position.x + position.y) % 2 == 0;
      return isDark ? mapGeneratorData.value.groundTiles[0] : mapGeneratorData.value.groundTiles[1];
      #endregion
    }

    /// <summary>Getter for the map generator data. if not already loaded it loads it</summary>
    /// <returns>The loaded map generation data</returns>
    private static MapGeneratorData GetMapGenerationData(MapGeneratorData _backer, bool isLoaded)
    {
      #region GetMapGenerationData
      if (!isLoaded)
        _backer = Resources.Load<MapGeneratorData>("MapGenerationData");

      return _backer;
      #endregion
    }

    /// <summary>Getter for the ground tile map</summary>
    /// <param name="_backer">The backer field provided by FieldGetter</param>
    /// <returns>The ground tilemap</returns>
    private static Tilemap GetTileMap(Tilemap _backer, bool isLoaded)
    {
      #region GetTileMap
      if (!isLoaded)
        _backer = GameObject.FindGameObjectWithTag("ground").GetComponent<Tilemap>();

      return _backer;
      #endregion
    }
    #endregion
  }
}
