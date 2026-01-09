using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
  public Tilemap ground;
  public Tilemap decals1;
  public Tilemap decals2;
  public Tilemap foliage;
  public Tilemap trees;
  public TileBase[] groundTiles;
  public TileBase[] darkDecals;
  public TileBase[] lightDecals;
  public TileBase[] foliageTiles;
  public TileBase[] treeTiles;
  public int size;


  public void Start()
  {
    for (int i = 0; i < size * size; i++)
    {
      int row = (i / size) - (size / 2);
      int col = (i % size) - (size / 2);

      Vector3Int pos = new Vector3Int(row, col, 0);
      ground.SetTile(pos, groundTiles[0]);

      if (Random.Range(0f, 1f) < 0.1f)
        decals1.SetTile(pos, darkDecals[Random.Range(0, darkDecals.Length - 1)]);

      if (Random.Range(0f, 1f) < 0.05f)
        decals2.SetTile(pos, lightDecals[Random.Range(0, lightDecals.Length - 1)]);

      if (Random.Range(0f, 1f) < 0.5f)
        foliage.SetTile(pos, foliageTiles[Random.Range(0, foliageTiles.Length - 1)]);

    }
  }
}
