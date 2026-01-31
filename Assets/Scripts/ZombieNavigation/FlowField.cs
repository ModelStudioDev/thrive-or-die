using UnityEngine;

public class FlowField
{
  public Cell[,] grid { get; private set; }  
  public Vector2Int gridSize { get; private set; }
  public float cellRadius { get; private set; }

  public float cellDiameter;

  public FlowField(float _cellRadius, Vector2Int _gridSize)
  {
    cellRadius = _cellRadius;
    cellDiameter = cellRadius * 2f;
    gridSize = _gridSize;
  }

  public void CreateGrid()
  {
    grid = new Cell[gridSize.x, gridSize.y];

    for (int i = 0; i < gridSize.x; i++)
    {
      for (int j = 0; j < gridSize.y; j++)
      {

      }
    }

  }

}
