using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Missile : MonoBehaviour
{
    [Header("Missile Parameters")]
    [SerializeField] private float missileSpeed;
    [SerializeField] private float rotationSpeed;

    [Header("Objects")]
    [SerializeField] private Transform explosion;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private List<Transform> listOfTargetPoints;
    private int currentTarget = 0;

    [Header("Points")]
    [SerializeField] private float meteorPoints;

    private static Vector2 targetPosition;

    private bool isShooting;
    private bool canShoot;

    #region Delegates

    public delegate void OnMissileLaunch();
    public static OnMissileLaunch onMissileLaunch;

    public delegate void OnMissileDestroyMeteor(float pointValue);
    public static OnMissileDestroyMeteor onMissileDestroyMeteor; 

    #endregion

    void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        Shooting();
        UpdateMissile();
    }
    private void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Transform newTargetPoint = Instantiate(targetPoint, targetPosition, targetPoint.rotation);
            listOfTargetPoints.Add(newTargetPoint);
            isShooting = true;
            canShoot = false;
            onMissileLaunch?.Invoke();
        }
    }

    private void UpdateMissile()
    {
        if (!isShooting)
        {
            return;
        }

        if (isShooting)
        {
            // Moving missile
            transform.position = Vector2.MoveTowards(transform.position, listOfTargetPoints[0].position, Time.deltaTime * missileSpeed);

            // Rotating missile
            Vector3 direction = (Vector3)listOfTargetPoints[0].position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            float distanceToTarget = Vector3.Distance(listOfTargetPoints[0].position, transform.position);
            Debug.Log(distanceToTarget);

            if (distanceToTarget <= 0.2f)
            {
                MissileExplosion();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteor"))
        {
            onMissileDestroyMeteor?.Invoke(meteorPoints);
            MissileExplosion();
        }
    }

    public void MissileExplosion()
    {
        Transform newExplosion = Instantiate(explosion);
        newExplosion.transform.position = transform.position;
        Destroy(this.gameObject);
    }
}
