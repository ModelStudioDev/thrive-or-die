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
  public TileBase[] decalTiles;
  public TileBase[] foliageTiles;
  public TileBase[] treeTiles;
  public int size;


  public void Start()
  {

  }
}
