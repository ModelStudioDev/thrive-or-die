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
  [SerializeField] private float cellRadius = 0.5f;
  /// <summary>
  /// The current flow field
  /// </summary>
  [SerializeField] private FlowField currentFlowField;
  /// <summary>
  /// The input system for the mouse
  /// </summary>
  private InputSystem_Actions mouseAction;

  private float mouseDown;

  private void Awake()
  {
    mouseAction = new InputSystem_Actions();
    mouseAction.UI.Enable();
  }
  private void InitializeFlowField()
  {
    currentFlowField = new FlowField(cellRadius, gridSize);
    currentFlowField.CreateGrid();
  }

  private void Update()
  {
    GetMouseInput();
  }

  private void GetMouseInput()
  {
    mouseDown = mouseAction.FindAction("Click").ReadValue<float>();
    if (mouseDown != 0) InitializeFlowField();
  }
}
