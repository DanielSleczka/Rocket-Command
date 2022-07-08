using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingController : MonoBehaviour
{
    [SerializeField] private List<Building> listOfBuildings;
    [SerializeField] private Shield shield;
    private Shield currentShield;
    [SerializeField] private Transform shieldPosition;

    public void InitializeController()
    {
        CreateShield();
    }

    public void UpdateController()
    {

    }

    public void ReactivatingShield()
    {
        if(currentShield != null)
        {
            Destroy(currentShield.gameObject);
        }
        CreateShield();
    }

    public void CreateShield()
    {
        currentShield = Instantiate(shield, shieldPosition);
    }
}
