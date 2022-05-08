using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private GameView gameView;
    [SerializeField] private float currentPoints;
    Vector2 scale = Vector2.one * 1.5f;

    private void Start()
    {
        currentPoints = 0f;
        AddPoints(currentPoints);
        Missile.onMissileDestroyObject += AddPoints;
        
    }

    public void AddPoints(float pointsValue)
    {
        currentPoints += pointsValue;
        gameView.UpdatePoints(currentPoints);
        if(currentPoints != 0)
            gameView.ChangeScale(scale);
    }


}
