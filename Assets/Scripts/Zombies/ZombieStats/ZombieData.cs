using UnityEngine;

namespace ThriveOrDie.Zombies
{
  [CreateAssetMenu(fileName = "ZombieData", menuName = "ScriptableObjects/ZombieData")]
  public class ZombieData : ScriptableObject
  {
    /// <summary>
    /// The max health of a zombie
    /// </summary>
    public float maxHealth;
    /// <summary>
    /// The strength value of a zombie
    /// </summary>
    public float strength;
    /// <summary>
    /// The zombie speed
    /// </summary>
    public float speed;

  }

}
