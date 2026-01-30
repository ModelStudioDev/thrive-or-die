using UnityEngine;

namespace ThriveOrDie.Zombies
{
  [CreateAssetMenu(fileName = "ZombieStats", menuName = "ScriptableObjects/ZombieStats")]
  public class ZombieStats : ScriptableObject
  {
    /// <summary>
    /// The name of the prefab
    /// </summary>
    public string prefabName;


    /// <summary>
    /// The position  at wich a zombie will spawn
    /// </summary>
    public Vector2[] spawnPoints;

    //public ZombieType type;
    //public ZombieLevel level;

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
