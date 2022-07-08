using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private GameView gameView;
    [SerializeField] private LoseView loseView;
    [SerializeField] private float currentPoints;
    Vector2 scale;

    public void InitializeSystem()
    {
        currentPoints = 0f;
        scale = Vector2.one * 1.5f;
        AddPoints(currentPoints);
        Missile.onMissileDestroyObject += AddPoints;
        Meteor.onDestroyObjectFromBonus += AddPoints;
    }

    public void ShowCurrentPoints()
    {
        loseView.ShowLastPoints(currentPoints);
    }

    public float GetCurrentPoints()
    {
        return currentPoints;
    }

    public void AddPoints(float pointsValue)
    {
        currentPoints += pointsValue;
        gameView.UpdatePoints(currentPoints);
        //if (currentPoints != 0)
        //    gameView.ChangeScale(scale);
    }


}
