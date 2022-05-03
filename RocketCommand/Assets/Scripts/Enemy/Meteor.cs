using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private GroundExplosion fxGroundExplosion;
    [SerializeField] private Explosion fxMeteorExplosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Ground"))
        {
            GroundExplosion();
        }        
        
        if (collision.CompareTag("Shield"))
        {
            MeteorExplosion();
        }

        if (collision.CompareTag("Building"))
        {
            MeteorExplosion();
        }
    }

    public void GroundExplosion()
    {
        GroundExplosion newExplosion = Instantiate(fxGroundExplosion);
        newExplosion.transform.position = transform.position;
        Destroy(gameObject);
    }
    
    public void MeteorExplosion()
    {
        Destroy(gameObject);
        Explosion newExplosion = Instantiate(fxMeteorExplosion);
        newExplosion.transform.position = transform.position;
        newExplosion.transform.localScale = new Vector3(2f, 2f, 2f);
    }
}
