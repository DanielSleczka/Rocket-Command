using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private Camera mainCamera;

    [Header("Missile")]
    [SerializeField] private Missile missile;
    [SerializeField] private List<Missile> currentMissiles;
    [SerializeField] private Transform startPosition;

    [Header("Shoot")]
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float missileSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform explosion;


    private Vector2 mousePosition;
    private static Vector2 objPosition;
    private static Vector2 targetPosition;
    private bool isShooting;

    



    private void Update()
    {
        SetShooting();
        ShootingUpdate();
    }

    private void SetShooting()
    {
        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        objPosition = mainCamera.ScreenToWorldPoint(mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Missile newMissile = Instantiate(missile);
            newMissile.transform.position = startPosition.position;
            currentMissiles.Add(newMissile);

            Transform newTargetPoint = Instantiate(targetPoint, objPosition, targetPoint.rotation);

            targetPosition = objPosition;
            isShooting = true;
        }
    }

    private void ShootingUpdate()
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
}
