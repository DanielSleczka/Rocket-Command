using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private EnemySpaceShip enemySpaceShip;
    private EnemySpaceShip currentEnemySpaceShip;
    [SerializeField] private float moveDuration;
    private bool move;
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

    [Header("Bonus")]
    [SerializeField] private ShootingController shootingController;
    [SerializeField] private MeteorController meteorController;
    [SerializeField] private BuildingController buildingController;
    [SerializeField] private List<Bonus> listOfBonuses;
    private Bonuses bonuses;


    public void InitializeController()
    {
        SetTimeToRespawn();
        Missile.onMissileDestroyEnemySpaceShip += DestroyEnemy;
    }

    public void UpdateController()
    {
        CheckRespawnCondition();
        if (move)
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
        if (currentTime >= timeToRespawn && !move)
        {
            CreateNewEnemyShip();
        }
        currentTime += Time.deltaTime;
    }

    public void CreateNewEnemyShip()
    {
        RandomizeDirection();
        currentEnemySpaceShip = Instantiate(enemySpaceShip);
        currentEnemySpaceShip.transform.position = startPosition;
        startTime = Time.time;
        move = true;
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
    }

    public void RemoveEnemy()
    {
        SetTimeToRespawn();
        move = false;
        Destroy(currentEnemySpaceShip.gameObject);
    }

    public void DestroyEnemy()
    {
        DropBonus();
        RemoveEnemy();
    }

    public void DropBonus()
    {
        Bonus newBonus = Instantiate(listOfBonuses[Random.Range(0, listOfBonuses.Count)]);
        newBonus.transform.position = currentEnemySpaceShip.transform.position;

        if (newBonus.bonus == Bonuses.SpeedBonus)
        {
            shootingController.RunSpeedBonus(5f);
        }

        else if (newBonus.bonus == Bonuses.SlowMo)
        {
            shootingController.RunSlowMoBonus(5f);
        }

        else if (newBonus.bonus == Bonuses.Shield)
        {
            buildingController.ReactivatingShield();
        }

        else if (newBonus.bonus == Bonuses.KillThemAll)
        {
            meteorController.DestroyAllMeteors();
        }
    }
}
