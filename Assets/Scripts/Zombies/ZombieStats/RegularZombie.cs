using ThriveOrDie.Zombies;
using UnityEngine;

public class RegularZombie : MonoBehaviour
{
  // This was just a test for the scriptable object. This will be deleted

  [SerializeField] private ZombieStats zombieStats;

  private void Start()
  {
    zombieStats.prefabName = "Regular zombie";
    zombieStats.maxHealth = 100f;
    zombieStats.speed = 7f;
    zombieStats.strength = 4f;
  }

}
