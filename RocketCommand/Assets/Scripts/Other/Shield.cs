using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private List<Transform> shields;
    [SerializeField] private AnimationCurve destroyCurve;
    [SerializeField] private float destroyDuration;
    private float startTime;

    private int currentShield = 2;
    private bool isHitting;

    private Color fullShieldColor = Color.white;
    private Color emptyShieldColor = Color.white;


    public void Start()
    {
        fullShieldColor.a = 1;
        emptyShieldColor.a = 0;
    }

    public void Update()
    {
        if (isHitting)
        {
            DestroyShield();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Meteor"))
        {
            startTime = Time.time;
            isHitting = true;
        }

        if (collision.CompareTag("EnemyProjectile"))
        {
            startTime = Time.time;
            isHitting = true;
        }
    }

    public void DestroyShield()
    {
        float timeProgress = (Time.time - startTime) / destroyDuration;
        shields[currentShield].transform.GetComponent<SpriteRenderer>().color = Color.Lerp(fullShieldColor, emptyShieldColor, destroyCurve.Evaluate(timeProgress));
        if (timeProgress >= 1)
        {
            Destroy(shields[currentShield].gameObject);
            currentShield--;
            if(currentShield < 0)
            {
                Destroy(gameObject);
            }
            isHitting = false;
        }
    }
}
