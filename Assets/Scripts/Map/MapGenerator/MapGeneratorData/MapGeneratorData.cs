using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Map Generation Data", menuName = "ThriveOrDie/Map Generation Data")]
public class MapGeneratorData : ScriptableObject
{
  /// <summary>The map size. Consider puting this in the Game manager instead?</summary>
  public int mapSize;
  /// <summary>the collection of ground tiles to use</summary>
  public TileBase[] groundTiles;

}
