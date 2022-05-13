using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] bulletPre;
    private float spawnRangeX = 20;
    private float spawnPosZ = 10;
    private float delayTime = 1;
    private float spawnInterval = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemies", delayTime, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBullets();
    }
    void SpawnBullets()
    {
        int bulletIndex = Random.Range(0, bulletPre.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 5.5f, spawnPosZ);
        Instantiate(bulletPre[bulletIndex], spawnPos, bulletPre[bulletIndex].transform.rotation);


    }
}