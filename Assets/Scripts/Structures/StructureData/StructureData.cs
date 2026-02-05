using UnityEngine;
using ThriveOrDie.Utils;
using UnityEngine.Tilemaps;
namespace ThriveOrDie.Structures
{
  [CreateAssetMenu(fileName = "Structure", menuName = "ThriveOrDie/Structure")]
  public class StructureData : ScriptableObject
  {
    /// <summary>Specific type of the structure</summary>
    public StructureType type;
    /// <summary>Name of the structure</summary>
    public string structureName;
    /// <summary>healt of the structure,scales with level</summary>
    public LevelScaler health = new();
    /// <summary>Size in space of the structure</summary>
    public int size;
    /// <summary>Maximum level achievable by the structure</summary>
    public int maxLevel;
    /// <summary>Matrix of tiles the structure takes</summary>
    public bool[][] footprint;
    /// <summary>The structure sprites, defined per-level</summary>
    public LevelDefined<TileBase> sprites = new();
  }
}
