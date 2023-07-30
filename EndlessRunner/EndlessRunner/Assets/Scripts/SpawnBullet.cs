using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bullet;

    public float spawnTime;
    public Transform spawnPosition; 
    float currentSpawnTime;

    private void Awake()
    {
        currentSpawnTime = spawnTime;
    }

    private void Update()
    {
        currentSpawnTime -= Time.deltaTime;
        if(currentSpawnTime <= 0)
        {
            currentSpawnTime = spawnTime;
            Instantiate(bullet, spawnPosition.position, Quaternion.identity);
        }
    }
}
