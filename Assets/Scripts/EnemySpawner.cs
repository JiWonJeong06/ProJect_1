using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField]private float spawnRate = 0.3f;
    [SerializeField]private float spawnRange = 10f;


    void Start()
    {
        InvokeRepeating("SpawnBullet", 1f, spawnRate);
    }

    void SpawnBullet()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(randomX, 6f, 0);

        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
    }
}