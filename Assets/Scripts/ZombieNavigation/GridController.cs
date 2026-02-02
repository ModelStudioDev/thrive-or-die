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
  [SerializeField] private float cellWidth = 1f;
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
    currentFlowField = new FlowField(cellWidth, gridSize);
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
    }
  }

  private void OnDrawGizmos()
  {
    if (currentFlowField?.grid == null) return;

    float halfWidth = currentFlowField.cellWidth / 2f;
    float halfHeight = currentFlowField.cellWidth * 0.25f;   // = (cellWidth / 2) / 2 = cellWidth * 0.25

    foreach (var cell in currentFlowField.grid)
    {
      Vector3 center = cell.worldPosition;

      Vector3 top = center + new Vector3(0, halfHeight, 0);
      Vector3 right = center + new Vector3(halfWidth, 0, 0);
      Vector3 bottom = center + new Vector3(0, -halfHeight, 0);
      Vector3 left = center + new Vector3(-halfWidth, 0, 0);

      float heat = cell.bestCost < 255 ? cell.bestCost / 40f : 1f;
      heat = Mathf.Clamp01(heat);
      Gizmos.color = Color.Lerp(Color.cyan, Color.red, heat);

      Gizmos.DrawLine(top, right);
      Gizmos.DrawLine(right, bottom);
      Gizmos.DrawLine(bottom, left);
      Gizmos.DrawLine(left, top);

      Gizmos.DrawSphere(center, 0.08f);

#if UNITY_EDITOR
      UnityEditor.Handles.Label(center + Vector3.up * 0.3f,
          $"{cell.gridIndex.x},{cell.gridIndex.y}\n{cell.bestCost}");
#endif
    }
  }

}
