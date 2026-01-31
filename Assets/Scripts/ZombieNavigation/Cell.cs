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

  public Cell(Vector3 _worldPosition, Vector2Int _gridIndex)
  {
    worldPosition = _worldPosition;
    gridIndex = _gridIndex;
  }
}

