

using ThriveOrDie.Map;
using ThriveOrDie.Structures;
using UnityEngine;

public class CreateStructureTest : MonoBehaviour
{

  public StructureData structureData;
  public Vector2Int position;

  void Awake()
  {
    MapManager.Singleton.CreateNewStructure(position, structureData);
  }
}
