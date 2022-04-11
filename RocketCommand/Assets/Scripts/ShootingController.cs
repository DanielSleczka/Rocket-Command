using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private Camera mainCamera;

    [Header("Missile")]
    [SerializeField] private Missile missile;
    [SerializeField] private Transform explosion;
    [SerializeField] private Transform startPosition;
    [SerializeField] private List<Missile> currentMissiles;

    [Header("Shoot")]
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float shootThreshold;
    [SerializeField] [Range(0f, 1f)] private float reloadProgress;
    [SerializeField] private float missileSpeed;
    [SerializeField] private float rotationSpeed;


    private Vector2 mousePosition;
    private static Vector2 objPosition;
    private static Vector2 targetPosition;
    private float lastTimeShoot;
    private bool isShooting;
    private bool canShoot;
    private bool isLoaded;
    private bool canReload;

    private void Start()
    {
        CreateNewMissile();
        canShoot = true;
        isLoaded = true;
    }


    private void Update()
    {
        Shooting();
        UpdateMissile();
    }

    private void Shooting()
    {
        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        objPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        if (!isLoaded)
        {
            CreateNewMissile();
            isLoaded = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            Transform newTargetPoint = Instantiate(targetPoint, objPosition, targetPoint.rotation);
            lastTimeShoot = Time.time;
            targetPosition = objPosition;
            isShooting = true;
            canShoot = false;
            canReload = true;
        }

        if (canReload)
        {
            ReloadMissile();
        }

    }
    private void UpdateMissile()
    {
        if (!isShooting)
            return;

        if (isShooting)
        {
            for (int i = currentMissiles.Count - 1; i >= 0; i--)
            {
                // Moving missile
                currentMissiles[i].transform.position = Vector2.MoveTowards(currentMissiles[i].transform.position, targetPosition, Time.deltaTime * missileSpeed);

                // Rotating missile
                Vector3 direction = (Vector3)targetPosition - currentMissiles[i].transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                currentMissiles[i].transform.rotation = Quaternion.Slerp(currentMissiles[i].transform.rotation, rotation, rotationSpeed * Time.deltaTime);

                // check when missile colliding with target point
                if (!currentMissiles[i].IsFlying)
                {
                    currentMissiles[i].MissileExplosion();
                    currentMissiles.Remove(currentMissiles[i]);
                    isShooting = false;
                }
            }
        }
    }
    public void ReloadMissile()
    {
        reloadProgress = (Time.time - lastTimeShoot) / shootThreshold;
        if (reloadProgress >= 1f)
        {
            canShoot = true;
            isLoaded = false;
            canReload = false;
        }
    }

    public void CreateNewMissile()
    {
        Missile newMissile = Instantiate(missile);
        newMissile.transform.position = startPosition.position;
        currentMissiles.Add(newMissile);
    }
}
