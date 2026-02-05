using System.Collections.Generic;
using System.Linq;
using ThriveOrDie.Structures;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace ThriveOrDie.Map
{
  public class MapManager : MonoBehaviour
  {
    #region Singleton setup
    /// <summary>Singleton instance of MapManager</summary>
    public static MapManager Singleton;
    /// <summary>Sets up the singleton</summary>
    private void SetupSingleton()
    {
      #region SetupSingleton
      if (Singleton != null && Singleton != this) { Destroy(gameObject); return; }
      if (Singleton != this) Singleton = this;
      #endregion
    }
    #endregion

    #region Data
    [Header("Map")]
    public short mapSize;
    public Tilemap structureTilemap;

    /// <summary>Store of the tile data</summary>
    public List<List<TileData>> tiles = new();
    /// <summary>Store of all present structures</summary>
    public List<Structure> structures = new();
    #endregion

    #region Unity
    /// <summary>Called by unity on awake</summary>
    private void Awake()
    {
      #region Awake
      SetupSingleton();
      CreateTiles();
      LoadStructures();
      #endregion
    }

    /// <summary>Method</summary>
    private void CreateTiles()
    {
      #region CreateTiles
      for (int x = 0; x < mapSize; x++)
      {
        List<TileData> column = new();
        for (int y = 0; y < mapSize; y++)
        {
          column.Add(new TileData());
        }
        tiles.Add(column);
      }
      #endregion
    }

    /// <summary>Loads the structures from file</summary>
    private void LoadStructures()
    {
      #region LoadStructures
      StructureStats[] structuresToLoad = SavesManager.LoadStructures();
      foreach (StructureStats structureStats in structuresToLoad)
      {
        Structure structure = new Structure(structureStats);
        structures.Add(structure);
        LoadFootprint(structure);
        RenderStructure(structure);
      }
      #endregion
    }

    /// <summary>Method</summary>
    public void CreateNewStructure(Vector2Int position, StructureData structureData)
    {
      #region CreateNewStructure
      Structure structure = new Structure(position, structureData);
      // TODO add footprint checks here
      structures.Add(structure);
      LoadFootprint(structure);
      RenderStructure(structure);
      #endregion
    }

    /// <summary>Loads the fotprint into the structureTiles if needes</summary>
    /// <param name="structure">The structure for which to load the footprint</param>
    private void LoadFootprint(Structure structure)
    {
      #region LoadFootprint
      var (originX, originY) = structure.structureStats.originPosition;

      bool[][] footprint = structure.structureStats.footprint;
      for (int footprintX = 0; footprintX < footprint[0].Count(); footprintX++)
      {
        for (int footprintY = 0; footprintY < footprint[1].Count(); footprintY++)
        {
          if (!footprint[footprintX][footprintY]) continue;
          int x = originX + footprintX;
          int y = originY + footprintY;

          tiles[x][y].structureTile.SetStructure(structure);
        }
      }
      #endregion
    }

    /// <summary>Renders the passed structure</summary>
    private void RenderStructure(Structure structure)
    {
      #region RenderStructure
      Vector3Int position = (Vector3Int)structure.structureStats.originPosition;
      TileBase tileBase = structure.GetTileBase();
      structureTilemap.SetTile(position, tileBase);
      #endregion
    }

    /// <summary>Transforms a grid position to a world position</summary>
    /// <param name="gridPosition">The grid position to transform</param>
    /// <returns>The world position</returns>
    public static Vector3 GridToWorld(Vector2Int gridPosition)
    {
      #region GridToWorld
      return Singleton.structureTilemap.CellToWorld((Vector3Int)gridPosition);
      #endregion
    }
    #endregion

  }
}
