using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Transform fxSmoke;
    [SerializeField] private Transform fxFire;

    private Transform newFxSmoke;
    private Transform newFxFire;
    private int healhPoints;
    private bool isHitted;

    private void Start()
    {
        healhPoints = 3;
    }

    private void Update()
    {
        if (isHitted && healhPoints == 2)
        {
            newFxSmoke = Instantiate(fxSmoke, transform.position, Quaternion.identity, transform);
            isHitted = false;
        }

        if (isHitted && healhPoints == 1)
        {
            Destroy(newFxSmoke.gameObject);
            newFxFire = Instantiate(fxFire, transform.position, Quaternion.identity, transform);
            isHitted = false;
        }

        if (isHitted && healhPoints == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Meteor"))
        {
            healhPoints--;
            isHitted = true;
        }

        if (collision.CompareTag("EnemyProjectile"))
        {
            healhPoints--;
            isHitted = true;
        }
    }

}
