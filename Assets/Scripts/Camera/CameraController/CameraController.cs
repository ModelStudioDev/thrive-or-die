using ThriveOrDie.Settings;
using UnityEngine;
using UnityEngine.InputSystem;
namespace ThriveOrDie.Camera
{
  /// <summaryControls the camera movement</summary>
  public class CameraController : MonoBehaviour
  {
    #region Data
    /// <summary>The camera speed</summary>
    private float cameraSpeed => 1f * SettingsManager.currentSettings.cameraSensibility;
    /// <summary>The size of the zone that triggers movement</summary>
    [SerializeField] private int moveZone;
    #endregion

    #region Unity
    /// <summary>Ran by unity</summary>
    private void Update()
    {
      #region Update
      MoveCamera();
      #endregion
    }
    #endregion

    #region Methods
    /// <summary>Moves the camera if needed</summary>
    private void MoveCamera()
    {
      #region MoveCamera
      Vector2 mousePosition = Mouse.current.position.ReadValue();

      int x = 0;
      int y = 0;

      if (mousePosition.y <= moveZone) y -= 1;
      if (mousePosition.x >= Screen.width - moveZone) x += 1;
      if (mousePosition.y >= Screen.height - moveZone) y += 1;
      if (mousePosition.x <= moveZone) x -= 1;

      Vector2 direction = new Vector2(x, y).normalized;
      if (direction == Vector2.zero) return;

      transform.Translate(direction * cameraSpeed * Time.deltaTime);
      #endregion
    }
    #endregion
  }
}
