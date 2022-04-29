using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceShip : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private Transform shootPosition;
    [SerializeField] private ESSProjectile projectile;

    [Header("Time")]
    [SerializeField] private float minTimeToShoot;
    [SerializeField] private float maxTimeToShoot;
    private float timeToShoot;

    private void Start()
    {
        timeToShoot = Random.Range(minTimeToShoot, maxTimeToShoot);
        StartCoroutine(RespawnNewProjectile(timeToShoot));
    }

    public void CreateProjectile()
    {
        ESSProjectile newProjectile = Instantiate(projectile);
        newProjectile.transform.position = shootPosition.position;

        timeToShoot = Random.Range(minTimeToShoot, maxTimeToShoot);
        StartCoroutine(RespawnNewProjectile(timeToShoot));
    }

    private IEnumerator RespawnNewProjectile(float delay)
    {
        yield return new WaitForSeconds(delay);
        CreateProjectile();
    }
}
