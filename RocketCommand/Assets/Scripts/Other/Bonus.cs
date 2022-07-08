using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bonus : MonoBehaviour
{
    [SerializeField] private int indexID;
    public int IndexID => indexID;


    [Header("Move")]
    [SerializeField] private float moveDuration;
    private float timeProgress;
    private float startTime;
    private Vector2 startPosition;
    private Vector2 endPosition;

    private UnityAction onDestroyBonusWithoutActivation;
    private UnityAction onDestroyBonusWithActivation;

    private void Awake()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        timeProgress = (Time.time - startTime) / moveDuration;
        transform.position = Vector2.Lerp(startPosition, endPosition, timeProgress);
        transform.Rotate(0f, 0f, -.3f, Space.Self);
        if (timeProgress >= 1f)
        {
            RemoveBonus();
        }
    }
    private void RemoveBonus()
    {
        onDestroyBonusWithoutActivation?.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Missile"))
        {
            onDestroyBonusWithActivation?.Invoke();
            Destroy(gameObject);
        }
    }

    public void OnDestroyBonusWithoutActivation_AddListener(UnityAction callback)
    {
        onDestroyBonusWithoutActivation += callback;
    }
    public void OnDestroyBonusWithActivation_AddListener(UnityAction callback)
    {
        onDestroyBonusWithActivation += callback;
    }

    public void SetPositions(Vector2 startPosition, Vector2 endPosition)
    {
        this.startPosition = startPosition;
        this.endPosition = endPosition;
    }

}

