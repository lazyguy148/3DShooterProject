using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform turretHead;
    [SerializeField] Transform targetPoint;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float fireRate = 3f;

    PlayerHealth player;
    private void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(FireRoutine());
    }

    void Update()
    {
        turretHead.LookAt(targetPoint.position);
    }

    IEnumerator FireRoutine()
    {
        while (player)
        {
            yield return new WaitForSeconds(fireRate);
            Instantiate(projectilePrefab, projectileSpawnPoint.position, turretHead.rotation);
        }

    }
}
