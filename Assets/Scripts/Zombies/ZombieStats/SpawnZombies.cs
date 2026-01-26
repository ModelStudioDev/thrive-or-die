using UnityEngine;

namespace ThriveOrDie.Zombies

{
  public class SpawnZombies : MonoBehaviour
  {
    public GameObject zombie;
    
  

    void Start()
    {
      SpawnEntities();
    }

    void SpawnEntities()
    {
      for (int i = 0; i < 3; i++)
      {
        GameObject newZombie = Instantiate(zombie, new Vector2(0, 0), Quaternion.identity);
      }
    
 
    }
  }
}
