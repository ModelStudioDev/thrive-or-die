using UnityEngine;

public class FlowField
{
  /// <summary>
  /// The 2D array of cells
  /// </summary>
  public Cell[,] grid { get; private set; }  
  /// <summary>
  /// The size of the grid
  /// </summary>
  public Vector2Int gridSize { get; private set; }
  /// <summary>
  /// The radius of a cell
  /// </summary>
  public float cellRadius { get; private set; }
  /// <summary>
  /// The diameter of a cell
  /// </summary>
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

    for (int x = 0; x < gridSize.x; x++)
    {
      for (int y = 0; y < gridSize.y; y++)
      {
        Vector3 worldPos = new Vector3(cellDiameter * x, cellDiameter * y + cellRadius, 0);
        grid[x,y] = new Cell(worldPos, new Vector2Int(x, y));
        Debug.Log(worldPos);
      }
    }

  }

}
