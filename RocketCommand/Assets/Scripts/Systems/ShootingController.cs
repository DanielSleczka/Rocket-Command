using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [Header("TimeToShoot")]
    [SerializeField] private SpriteRenderer loadingImage;
    [SerializeField] private float shootThreshold;
    [SerializeField] [Range(0f, 1f)] private float reloadProgress;
    private float lastTimeShoot;

    [Header("Missile")]
    [SerializeField] private Transform startPosition;
    [SerializeField] private Missile missile;
    [SerializeField] private float missileSpeed;
    public float MissileSpeed => missileSpeed;

    private bool isLoaded;
    private bool canReload;

    private void Start()
    {
        CreateNewMissile();
        isLoaded = true;
        Missile.onMissileLaunch += EnableReload;
    }
    private void Update()
    {
        CreatingMissile();
    }

    private void CreatingMissile()
    {
        if (!isLoaded)
        {
            CreateNewMissile();
            isLoaded = true;
        }

        if (canReload)
        {
            ReloadMissile();
        }
    }

    public void EnableReload()
    {
        lastTimeShoot = Time.time;
        canReload = true;
    }
    public void ReloadMissile()
    {
        reloadProgress = (Time.time - lastTimeShoot) / shootThreshold;

        Color loadingColor = loadingImage.color;
        loadingColor.a = reloadProgress;
        loadingImage.color = loadingColor;

        if (reloadProgress >= 1f)
        {
            isLoaded = false;
            canReload = false;
        }
    }

    public void CreateNewMissile()
    {
        Missile newMissile = Instantiate(missile);
        newMissile.transform.position = startPosition.position;
    }
}
