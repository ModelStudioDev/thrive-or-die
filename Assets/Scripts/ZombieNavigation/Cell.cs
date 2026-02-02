using Unity.Mathematics;
using UnityEngine;

public class Cell
{
  /// <summary>
  /// The world position of each cell
  /// </summary>
  public Vector3 worldPosition;
  /// <summary>
  /// The index position of each cell
  /// </summary>
  public Vector2Int gridIndex;
  /// <summary>
  /// The cost of each cell
  /// </summary>
  public byte cost;
  /// <summary>
  /// Represents the best cost for going to another cell from this cell
  /// </summary>
  public byte bestCost;
  /// <summary>
  /// Represents the direction
  /// </summary>
  public float2 vector;

  public Cell(Vector3 _worldPosition, Vector2Int _gridIndex)
  {
    worldPosition = _worldPosition;
    gridIndex = _gridIndex;
    cost = 1;
    bestCost = 255;
    vector = float2.zero;
  }
}

