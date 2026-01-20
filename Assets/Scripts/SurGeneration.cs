using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class SurGeneration : MonoBehaviour
{
    [SerializeField] private Rigidbody2D survivorPrefab;
    [SerializeField] private BoxCollider2D target;
    [SerializeField] private BoxCollider2D target2;
    [SerializeField] private BoxCollider2D target3;
    [SerializeField] float speed = 6f;

    [Header("Spawning Timer")]
    [SerializeField] float spawnInterval = 3f;
    private Rigidbody2D survivor;
    int counter = 0;

    bool secondSurvivor = true;
    bool stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    void Update()
    {

        if (survivor != null)
        {
            survivor.transform.position = Vector3.MoveTowards(survivor.transform.position, target.transform.position, speed * Time.deltaTime);
        }


    }

    int RSpawner()
    {
        int rNumber = Random.Range(1, 1000);
        return rNumber;
    }

    IEnumerator SpawnTimer()
    {
        while (stopSpawning == false)
        {
            if (counter > 2) stopSpawning = true;
            if (RSpawner() > 900 && counter <= 2)
            {
                survivor = Instantiate(survivorPrefab);
                survivor.transform.position = target2.transform.position;
                counter++;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
        Debug.Log("Spawning stoped");
    }
}



