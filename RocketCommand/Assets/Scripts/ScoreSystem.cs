using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private float currentPoints;
    [SerializeField] private GameView gameView;

    private void Start()
    {
        currentPoints = 0f;
        AddPoints(currentPoints);
        Missile.onMissileDestroyMeteor += AddPoints;
    }

    public void AddPoints(float pointsValue)
    {
        currentPoints += pointsValue;
        gameView.UpdatePoints(currentPoints);
    }
}
