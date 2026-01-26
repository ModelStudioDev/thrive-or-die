using UnityEngine;

namespace ThriveOrDie.Settings
{

  /// <summary>The player settings SO</summary
  [CreateAssetMenu(fileName = "Player Settings", menuName = "ThriveOrDie/Player Settings")]
  public class PlayerSettings : ScriptableObject
  {
    [Header("Controls")]
    /// <summary>The camera sensibility multiplayer</summary>
    public float cameraSensibility = 1f;
  }
}
