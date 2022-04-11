using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Missile : MonoBehaviour
{
    [SerializeField] private Transform explosion;
    [SerializeField] private bool isFlying;
    public bool IsFlying => isFlying;

    private void Awake()
    {
        isFlying = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TargetPoint"))
        {
            // change status of missile in ShootingController Update, which launch MissileExplosion in script Missile 
            isFlying = false;
        }

        if (collision.CompareTag("Meteor"))
        {
            isFlying = false;
        }
    }

    public void MissileExplosion()
    {
        Transform newExplosion = Instantiate(explosion);
        newExplosion.transform.position = transform.position;
        Destroy(this.gameObject);
    }


}
