using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsValue;


    public void UpdatePoints(float value)
    {
        pointsValue.text = $"Points: {value}";
    }

}
