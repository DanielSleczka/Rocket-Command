using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private Transform enemySpaceShip;
    [SerializeField] private Transform currentEnemySpaceShip;
    [SerializeField] private float moveDuration;
    [SerializeField] private BonusSystem bonusSystem;
    private bool canRespawn;
    private float startTime;

    [Header("Respawn Time")]
    [SerializeField] private float minTimeToRespawn;
    [SerializeField] private float maxTimeToRespawn;
    private float timeToRespawn;
    private float currentTime;
    [SerializeField] [Range(0f, 1f)] private float timeProg;

    [Header("Respawns")]
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 endPosition;




    public void InitializeController()
    {
        SetTimeToRespawn();
        Missile.onMissileDestroyEnemySpaceShip += DestroyShipWithBonus;
    }

    public void UpdateController()
    {
        Debug.Log(canRespawn);
        CheckRespawnCondition();
        if (currentEnemySpaceShip != null)
        {
            timeProg = (Time.time - startTime) / moveDuration;
            currentEnemySpaceShip.transform.position = Vector2.Lerp(startPosition, endPosition, timeProg);
            if (timeProg >= 1f)
            {
                RemoveEnemy();
            }
        }
    }
    public void CheckRespawnCondition()
    {
        if (currentTime >= timeToRespawn && canRespawn)
        {
            CreateNewEnemyShip();
        }
        currentTime += Time.deltaTime;
    }

    public void CreateNewEnemyShip()
    {
        RandomizeDirection();
        currentEnemySpaceShip = Instantiate(enemySpaceShip);
        currentEnemySpaceShip.position = startPosition;
        startTime = Time.time;
        canRespawn = false;
    }
    public void RandomizeDirection()
    {
        if (Random.Range(0, 101) < 50)
        {
            startPosition.x *= -1f;
            endPosition.x *= -1f;
        }
    }

    public void SetTimeToRespawn()
    {
        timeToRespawn = Random.Range(minTimeToRespawn, maxTimeToRespawn);
        currentTime = 0f;
        canRespawn = true;
    }

    public void RemoveEnemy()
    {
        SetTimeToRespawn();
        Destroy(currentEnemySpaceShip.gameObject);
    }

    public void DestroyShipWithBonus()
    {
        Debug.Log("DestroyShipWithBonus");
        SetTimeToRespawn();
        //bonusSystem.RandomizeBonus();
    }
}
