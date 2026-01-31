using UnityEngine;

public class Cell
{
  public Vector3 worldPosition;
  public Vector2Int gridIndex;

  public Cell(Vector3 _worldPosition, Vector2Int _gridIndex)
  {
    worldPosition = _worldPosition;
    gridIndex = _gridIndex;
  }
}

