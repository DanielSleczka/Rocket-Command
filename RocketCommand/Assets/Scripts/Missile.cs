using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float missileSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float duration;
    [SerializeField] private GameObject explosion;

    private float startTime;
    public bool isShooting;

    private void Start()
    {
        Shooting.targetPosition = Shooting.objPosition;
        startTime = Time.time;
        isShooting = true;

    }



    private void Update()
    {
        if (!isShooting)
            return;

        if(isShooting)
        {
            float distance = Vector2.Distance(Shooting.targetPosition, transform.position);

            Debug.Log(distance);

            transform.position = Vector2.Lerp(transform.position, Shooting.targetPosition, Time.deltaTime * missileSpeed);


            if (distance < 0.5f)
            {
                MissileExplosion();
            }
        }

        Vector3 direction = transform.position - (Vector3)Shooting.targetPosition;
        Debug.Log($"Direction: {direction}");

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

    }

    private void MissileExplosion()
    {
        isShooting = false;
        GameObject newExplosion = Instantiate(explosion);
        newExplosion.transform.position = transform.position;
        Destroy(this.gameObject);
        Destroy(newExplosion, 2f);
    }
}
