using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BonusSystem : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private ShootingController shootingController;
    [SerializeField] private MeteorController meteorController;
    [SerializeField] private BuildingController buildingController;

    [Header("Bonus")]
    [SerializeField] private Vector2 bonusPosition;
    [SerializeField] private List<Bonus> listOfBonuses;
    private Bonus currentBonus;

    [Header("Time")]
    [SerializeField] private float minTimeToRespawn;
    [SerializeField] private float maxTimeToRespawn;
    private float timeToRespawn;
    private float currentTime;

    [Header("Respawns")]
    [SerializeField] private bool canRespawn;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 endPosition;


    Vector3 upScale;
    Vector2 downScale;


    public void Start()
    {
        SetTimeToRespawn();
    }

    private void Update()
    {
        CheckRespawnCondition();
    }

    public void CheckRespawnCondition()
    {
        if (currentTime >= timeToRespawn && canRespawn)
        {
            CreateBonus();
        }
        currentTime += Time.deltaTime;
    }

    public void CreateBonus()
    {
        RandomizeDirection();
        currentBonus = Instantiate(listOfBonuses[Random.Range(0, listOfBonuses.Count)]);
        currentBonus.transform.position = startPosition;
        currentBonus.SetPositions(startPosition, endPosition);
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

    public void RandomizeBonus()
    {
        Bonus newBonus = Instantiate(listOfBonuses[Random.Range(0, listOfBonuses.Count)]);
        newBonus.transform.position = bonusPosition;


        if (newBonus.IndexID == 1)
        {
            shootingController.RunSpeedBonus(5f);
        }

        else if (newBonus.IndexID == 2)
        {
            shootingController.RunSlowMoBonus(5f);
        }

        else if (newBonus.IndexID == 3)
        {
            buildingController.ReactivatingShield();
        }

        else if (newBonus.IndexID == 4)
        {
            meteorController.DestroyAllMeteors();
        }
    }

}
