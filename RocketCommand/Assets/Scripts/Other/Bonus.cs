using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    private void Start()
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
        Destroy(gameObject);
    }


    public void SetPositions(Vector2 startPosition, Vector2 endPosition)
    {
        this.startPosition = startPosition;
        this.endPosition = endPosition;
    }


    //public void AnimRotateObject(GameObject objectToRotate)
    //{
    //    objectToRotate.transform.Rotate(0f, 0f, -.3f, Space.Self);
    //}
}

