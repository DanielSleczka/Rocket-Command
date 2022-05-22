using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private GroundExplosion fxGroundExplosion;
    [SerializeField] private Explosion fxMeteorExplosion;

    [SerializeField] private PointsPopup pointsPopup;
    [SerializeField] private float meteorPoints;

    public delegate void OnDestroyObjectFromBonus(float pointValue);
    public static OnDestroyObjectFromBonus onDestroyObjectFromBonus;
    

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
        newExplosion.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }    
    
    public void GetPointsFromMeteors()
    {
        onDestroyObjectFromBonus?.Invoke(meteorPoints);
        ShowPointsOnScreen(meteorPoints);
    }

    public void ShowPointsOnScreen(float pointsValue)
    {
        PointsPopup showPoints = Instantiate(pointsPopup, transform.position, Quaternion.identity);
        showPoints.Setup(pointsValue);
    }

}
