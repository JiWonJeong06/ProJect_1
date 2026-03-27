using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    public float minSpawnDelay = 1.2f;
    public float maxSpawnDelay = 2.5f;

    public float minY = -2f;
    public float maxY = 1f;

    public float spawnX = 12f;

    void Start()
    {
        SpawnLoop();
    }

    void SpawnLoop()
    {
        SpawnObstacle();

        float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
        Invoke(nameof(SpawnLoop), delay);
    }

    void SpawnObstacle()
    {
        int rand = Random.Range(0, obstaclePrefabs.Length);
        float yPos = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(spawnX, yPos, 0f);

        Instantiate(obstaclePrefabs[rand], spawnPos, Quaternion.identity);
    }
}