using UnityEngine;

namespace ThriveOrDie.Zombies

{
  public class SpawnZombies : MonoBehaviour
  {
    // This was just a test to see if the scriptable object was working
    public GameObject zombie;
    
    void Start()
    {
      SpawnEntities();
    }

    void SpawnEntities()
    {
      for (int i = 0; i < 3; i++)
      {
        GameObject newZombie = Instantiate(zombie);
        if (newZombie != null) Debug.Log("Zombie spawned");
        if (newZombie.GetComponent<SpriteRenderer>() == null) Debug.Log("Renderer not working"); // The object doesnt have this I think
        if (newZombie.GetComponent<Sprite>() == null) Debug.Log("Sprites not working");  // Nor this
      }
      
    }
  }
}
