using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    private static float defaultShootThreshold;
    private static float defaultMissileSpeed;

    private bool isLoaded;
    private bool canReload;


    private UnityAction onGameOver;


    public void InitializeController()
    {
        isLoaded = false;
        Missile.onMissileLaunch += EnableReload;
        defaultShootThreshold = shootThreshold;
        defaultMissileSpeed = missileSpeed;
    }
    public void UpdateController()
    {
        CreatingMissile();
    }

    public void CreatingMissile()
    {
        if (isLoaded == false)
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
        Missile newMissile = Instantiate(missile, startPosition);
        newMissile.SetMissileSpeed(missileSpeed);
    }

    public void RunSlowMoBonus(float timeProgress)
    {
        Time.timeScale = 0.5f;
        missileSpeed *= 2f;
        shootThreshold /= 2f;

        StartCoroutine(SlowMoBonusDefaultValues(timeProgress));
    }
    private IEnumerator SlowMoBonusDefaultValues(float timeProgress)
    {
        yield return new WaitForSeconds(timeProgress);
        Time.timeScale = 1f;
        missileSpeed = defaultMissileSpeed;
        shootThreshold = defaultShootThreshold;
    }
    public void RunSpeedBonus(float timeProgress)
    {
        missileSpeed *= 2f;
        shootThreshold = 0f;
        StartCoroutine(SpeedBonusDefaultValues(timeProgress));
    }
    private IEnumerator SpeedBonusDefaultValues(float timeProgress)
    {
        yield return new WaitForSeconds(timeProgress);
        missileSpeed = defaultMissileSpeed;
        shootThreshold = defaultShootThreshold;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Meteor") || collision.CompareTag("EnemyProjectile"))
        {
            onGameOver.Invoke();
        }
    }

    public void GameOver_AddListener(UnityAction callback)
    {
        onGameOver += callback;
    }



}
