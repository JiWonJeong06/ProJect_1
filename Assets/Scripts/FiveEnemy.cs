using UnityEngine;
using System.Collections.Generic;

public class FiveEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate = 0.5f;
    [SerializeField] private float spawnChance = 0.7f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPattern), 1f, spawnRate);
    }

    void SpawnPattern()
    {
        List<Transform> selected = new List<Transform>();

        foreach (Transform point in spawnPoints)
        {
            if (Random.value < spawnChance)
            {
                selected.Add(point);
            }
        }

        // 5개 전부 하나 제거
        if (selected.Count == spawnPoints.Length)
        {
            int removeIndex = Random.Range(0, selected.Count);
            selected.RemoveAt(removeIndex);
        }

        foreach (Transform point in selected)
        {
            Instantiate(bulletPrefab, point.position, Quaternion.identity);
        }
    }
}