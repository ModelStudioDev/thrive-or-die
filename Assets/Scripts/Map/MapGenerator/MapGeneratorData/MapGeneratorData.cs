using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "MapGenerationData", menuName = "ThriveOrDie/Map Generation Data")]
public class MapGeneratorData : ScriptableObject
{
  /// <summary>The map size. Consider puting this in the Game manager instead?</summary>
  public int mapSize;
  /// <summary>The collection of ground tiles to use</summary>
  public TileBase[] groundTiles;
}
