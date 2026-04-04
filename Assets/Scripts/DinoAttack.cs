using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]private float fireRate = 1f;

    void Start()
    {
        InvokeRepeating("Fire", 0f, fireRate);
    }

    void Fire()
    {
        Vector3 spawnPos = transform.position + Vector3.up * 0.5f;
        Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
    }
}