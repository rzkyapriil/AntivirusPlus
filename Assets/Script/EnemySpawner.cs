using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    void Awake()
    {
        Instance = this;
    }
    public List<GameObject> prefabsEnemies;
    public List<Transform> spawnPoint;
    public float spawnInterval; 

    public void StartSpawning()
    {
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(spawnInterval);
        StartCoroutine(SpawnDelay());
    }

    void SpawnEnemy()
    {
        int randomPrefabID = Random.Range(0, prefabsEnemies.Count);
        int randomSpawnID = Random.Range(0, spawnPoint.Count);
        GameObject spawnedEnemy = Instantiate(prefabsEnemies[randomPrefabID], spawnPoint[randomSpawnID]);
    }
}
