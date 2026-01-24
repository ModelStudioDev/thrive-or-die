using UnityEngine;

namespace ThriveOrDie.Zombies
{
  [CreateAssetMenu(fileName = "ZombieStats", menuName = "Scriptable Objects/ZombieStats")]
  public class ZombieStats : ScriptableObject
  {
    public string prefabName;

    public int numberOfPrefabsToCreate;
    public Vector2[] spawnPoints;

    public ZombieType type;
    private ZombieLevel level;

    public float maxHealth;
    public float strength;
    public float speed;

  }

}
