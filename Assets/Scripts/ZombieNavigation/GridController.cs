using UnityEngine.InputSystem;
using UnityEngine;


public class GridController : MonoBehaviour
{
  /// <summary>
  /// The grid size
  /// </summary>
  [SerializeField] private Vector2Int gridSize;
  /// <summary>
  /// The radius of a cell
  /// </summary>
  [SerializeField] private float cellWeidth = 1f;
  /// <summary>
  /// The current flow field
  /// </summary>
  public FlowField currentFlowField;
  /// <summary>
  /// The input system for the mouse
  /// </summary>
  private InputSystem_Actions mouseAction;

  [SerializeField] private GameObject square;

  private float mouseDown;

  private void Awake()
  {
    mouseAction = new InputSystem_Actions();
    mouseAction.UI.Enable();
  }
  private void InitializeFlowField()
  {
    currentFlowField = new FlowField(cellWeidth, gridSize);
    currentFlowField.CreateGrid();
    if (currentFlowField == null) Debug.Log("Flow field null");
  }


  private void Update()
  {
    GetMouseInput();
  }

  private void GetMouseInput()
  {
    mouseDown = mouseAction.FindAction("Click").ReadValue<float>();
    if (mouseDown != 0)
    {
      InitializeFlowField();
      ShowGrid();
    }
  }

  private void ShowGrid()
  {
    for (int i = 0; i < gridSize.x; i++)
    {
      for(int j = 0; j < gridSize.y; j++)
      {
        Cell cell = currentFlowField.grid[i, j];
        GameObject newSquare = Instantiate(square, cell.worldPosition, Quaternion.identity);
        newSquare.transform.rotation = Quaternion.Euler(0, 0, 45);
        newSquare.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        Debug.Log("Square instantiated");
      }
    }
  }
}
