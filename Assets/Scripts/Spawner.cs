using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            // Select a random item from array and instantiate
            int Index = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[Index], transform.position, Quaternion.identity);

            // Wait for a random time between 1.5 and 2.5 seconds before repeating
            float waitTime = Random.Range(1.5f, 2.5f);
            yield return new WaitForSeconds(waitTime);
        }

    }
    private void ontriggerEnter2D(Collider2D collision)
    {
      Destroy(collision.gameObject);
    }
}
