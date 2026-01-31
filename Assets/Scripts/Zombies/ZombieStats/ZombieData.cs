using UnityEngine;

namespace ThriveOrDie.Zombies
{
  [CreateAssetMenu(fileName = "ZombieData", menuName = "ScriptableObjects/ZombieData")]
  public class ZombieStats : ScriptableObject
  {
    /// <summary>
    /// The position  at wich a zombie will spawn
    /// </summary>
    public Vector2[] spawnPoints;
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
