using Unity.Mathematics;
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
  public float cellWidth { get; private set; }
  /// <summary>
  /// The diameter of a cell
  /// </summary>
  public float cellHeight;

  public FlowField(float _cellWidth, Vector2Int _gridSize)
  {
    cellWidth = _cellWidth;
    cellHeight = cellWidth / 2f;
    gridSize = _gridSize;
  }

  public void CreateGrid()
  {
    Debug.Log("Create grid started");
    grid = new Cell[gridSize.x, gridSize.y];
    for (int x = 0; x < gridSize.x; x++)
    {
      for (int y = 0; y < gridSize.y; y++)
      {
        Vector3 worldPos = new Vector3((x - y) * (cellWidth / 2), (x + y) * (cellHeight / 2), 0);
        grid[x,y] = new Cell(worldPos, new Vector2Int(x, y));

       
        Debug.Log(worldPos);
      }
    }

  }



}
