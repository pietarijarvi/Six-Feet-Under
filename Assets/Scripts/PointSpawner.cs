using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    public GameObject pickUpPoint;
    float rand;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            rand = Random.Range(8f, 18f);
            whereToSpawn = new Vector2(rand, transform.position.y);
            Instantiate(pickUpPoint, whereToSpawn, Quaternion.identity);
        }
    }
}

