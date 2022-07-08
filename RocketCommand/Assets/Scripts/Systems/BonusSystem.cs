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

    public void Start()
    {
        SetTimeToRespawn();
    }

    private void Update()
    {
        CheckRespawnCondition();

        Debug.Log(currentBonus);
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
        currentBonus.OnDestroyBonusWithoutActivation_AddListener(SetTimeToRespawn);
        currentBonus.OnDestroyBonusWithActivation_AddListener(ActivateBonus);
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

    public void ActivateBonus()
    {
        
        if (currentBonus.IndexID == 1)
        {
            shootingController.RunSpeedBonus(5f);
        }

        else if (currentBonus.IndexID == 2)
        {
            shootingController.RunSlowMoBonus(5f);
        }

        else if (currentBonus.IndexID == 3)
        {
            buildingController.ReactivatingShield();
        }

        else if (currentBonus.IndexID == 4)
        {
            meteorController.DestroyAllMeteors();
        }

        SetTimeToRespawn();
    }

}
