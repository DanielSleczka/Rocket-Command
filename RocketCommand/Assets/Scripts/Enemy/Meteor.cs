using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private MeteorExplosion fxMeteorExplosion;
    [SerializeField] private Explosion fxMeteorSecondExplosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Ground"))
        {
            MeteorExplosion();
        }

        if (collision.CompareTag("Building"))
        {
            MeteorSecondExplosion();
        }
    }

    public void MeteorExplosion()
    {
        MeteorExplosion newExplosion = Instantiate(fxMeteorExplosion);
        newExplosion.transform.position = transform.position;
        Destroy(gameObject);
    }
    
    public void MeteorSecondExplosion()
    {
        Explosion newExplosion = Instantiate(fxMeteorSecondExplosion);
        newExplosion.transform.position = transform.position;
        newExplosion.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
}
