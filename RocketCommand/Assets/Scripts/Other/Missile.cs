using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Missile : MonoBehaviour
{
    private float missileSpeed;
    private float rotationSpeed = 30;

    [Header("Objects")]
    [SerializeField] private Transform explosion;
    [SerializeField] private Transform targetPoint;
    private Transform currentTarget;

    [Header("Points")]
    [SerializeField] private PointsPopup pointsPopup;
    [SerializeField] private float meteorPoints;
    [SerializeField] private float enemyShipPoints;


    private static Vector2 targetPosition;

    private bool isShooting;
    private bool canShoot;

    #region Delegates

    public delegate void OnMissileLaunch();
    public static OnMissileLaunch onMissileLaunch;

    public delegate void OnMissileDestroyEnemySpaceShip();
    public static OnMissileDestroyEnemySpaceShip onMissileDestroyEnemySpaceShip;

    public delegate void OnMissileDestroyObject(float pointValue);
    public static OnMissileDestroyObject onMissileDestroyObject;


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
            currentTarget = newTargetPoint;
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
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * missileSpeed);

            // Rotating missile
            Vector3 direction = (Vector3)currentTarget.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            // Count distance
            float distanceToTarget = Vector3.Distance(currentTarget.position, transform.position);
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
            Destroy(collision);
            onMissileDestroyObject?.Invoke(meteorPoints);
            ShowPointsOnScreen(meteorPoints);
            MissileExplosion();
        }

        if (collision.CompareTag("EnemySpaceShip"))
        {
            onMissileDestroyObject?.Invoke(enemyShipPoints);
            onMissileDestroyEnemySpaceShip?.Invoke();
            ShowPointsOnScreen(enemyShipPoints);
            //Destroy(collision.gameObject);
            MissileExplosion();
        }
    }

    public void MissileExplosion()
    {
        Transform newExplosion = Instantiate(explosion);
        newExplosion.transform.position = transform.position;
        Destroy(this.gameObject);
    }

    public void ShowPointsOnScreen(float pointsValue)
    {
        PointsPopup showPoints = Instantiate(pointsPopup, transform.position, Quaternion.identity);
        showPoints.Setup(pointsValue);
    }

    public void SetMissileSpeed(float missileSpeed)
    {
        this.missileSpeed = missileSpeed;
    }
}
