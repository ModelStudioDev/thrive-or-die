using UnityEngine;

namespace ThriveOrDie.Zombies
{
  [CreateAssetMenu(fileName = "ZombieStats", menuName = "ScriptableObjects/ZombieStats")]
  public class ZombieStats : ScriptableObject
  {
    public string prefabName;

    public Sprite[] idleSprites;
    public Sprite[] atackSprites;
    public Sprite[] walkingSprites;
    public Sprite[] runningSprites;
    public Sprite[] deathSprites;

    public int numberOfPrefabsToCreate;
    public Vector2[] spawnPoints;

    //public ZombieType type;
    //public ZombieLevel level;

    public float maxHealth;
    public float strength;
    public float speed;

  }

}
