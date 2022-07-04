using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BuildingController : MonoBehaviour
{
    [SerializeField] private List<Building> listOfBuildings;
    [SerializeField] private Shield shield;
    [SerializeField] private Transform shieldPosition;

    private bool canCreateNewShield;

    public void InitializeController()
    {
        CreateShield();
    }

    public void UpdateController()
    {
        if(shield.IsDestroyed)
        {
            canCreateNewShield = true;
        }
    }

    public void ReactivatingShield()
    {
        CreateShield();
        //if (canCreateNewShield)
        //{
        //    CreateShield();
        //}
    }

    public void CreateShield()
    {
        Shield newShield = Instantiate(shield, shieldPosition);
        shield = newShield;
        canCreateNewShield = false;
    }
}
