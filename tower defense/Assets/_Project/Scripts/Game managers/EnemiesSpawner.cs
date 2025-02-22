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
public static class ExtensionMethods
{
    public static float GetPathRemainingDistance(this NavMeshAgent navMeshAgent)
    {
        if (navMeshAgent.pathPending ||
            navMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid ||
            navMeshAgent.path.corners.Length == 0)
            return -1f;

        float distance = 0.0f;
        for (int i = 0; i < navMeshAgent.path.corners.Length - 1; ++i)
        {
            distance += Vector3.Distance(navMeshAgent.path.corners[i], navMeshAgent.path.corners[i + 1]);
        }

        return distance;
    }
}