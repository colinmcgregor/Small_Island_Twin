using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject[] enemies;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1.0f, 3.0f);
    }

    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        GameObject randomEnemy = enemies[Random.Range(0,2)];
        Vector3 randomSpawnLocation = spawnPoints[Random.Range(0,6)].transform.position;
        
        Instantiate(randomEnemy, randomSpawnLocation, Quaternion.identity);
    }
}
