using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSpawner : MonoBehaviour
{
[SerializeField] private GameObject[] PowerUps;
    void Start()
    {
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            // Select a random item from array and instantiate
            int Index = Random.Range(0, PowerUps.Length);
            Instantiate(PowerUps[Index], transform.position, Quaternion.identity);

            // Wait for a random time between 1.5 and 2.5 seconds before repeating
            float waitTime = Random.Range(12.5f, 15.5f);
            yield return new WaitForSeconds(waitTime);
        }

    }
    private void ontriggerEnter2D(Collider2D collision)
    {
      Destroy(collision.gameObject);
    }
}

