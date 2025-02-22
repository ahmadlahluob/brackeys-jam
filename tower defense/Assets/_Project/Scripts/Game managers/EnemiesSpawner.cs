using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] int waves = 3;
    private int currentWave = 0;
    [SerializeField] float spawnRate;
    [SerializeField] int spawnCount;
    
    [SerializeField] GameObject[] enemies;
    private int spawnedEnemies = 0;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform target;
    void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
        
    }

    void Spawn()
    {
        if (currentWave == 0)
            currentWave++;
        GameObject enemy = PickRandom(enemies);
        var temp = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        temp.GetComponent<NavMeshAgent>().SetDestination(target.position);
    }

    GameObject PickRandom(GameObject[] enemies)
    {
        return(enemies[Random.Range(0, enemies.Length)]);
    }
}
