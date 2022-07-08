using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LoseView : BaseView
{
    [SerializeField] private CustomButton restartButton;
    [SerializeField] private CustomButton exitButton;

    [SerializeField] private TextMeshProUGUI lastGamePointsValue;
    [SerializeField] private TextMeshProUGUI highScorePointsValue;

    public void InitializeView()
    {
        restartButton.onMouseEnter.AddListener(() => ScaleButtonUp(restartButton));
        restartButton.onMouseExit.AddListener(() => ScaleButtonDown(restartButton));

        exitButton.onMouseEnter.AddListener(() => ScaleButtonUp(exitButton));
        exitButton.onMouseExit.AddListener(() => ScaleButtonDown(exitButton));
    }

    public void ShowLastPoints(float value)
    {
        lastGamePointsValue.text = $"{value}";
    }    
    
    public void ShowHighScorePoints(float value)
    {
        highScorePointsValue.text = $"{value}";
    }



    public void OnRestartGameButtonClicked_AddListener(UnityAction listener)
    {
        restartButton.onClick.AddListener(listener);
    }

    public void OnRestartGameButtonClicked_RemoveListener(UnityAction listener)
    {
        restartButton.onClick.RemoveListener(listener);
    }

    public void OnExitButtonClicked_AddListener(UnityAction listener)
    {
        exitButton.onClick.AddListener(listener);
    }

    public void OnExitButtonClicked_RemoveListener(UnityAction listener)
    {
        exitButton.onClick.RemoveListener(listener);
    }
}
