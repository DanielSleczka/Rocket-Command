using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoseView : BaseView
{
    [SerializeField] CustomButton restartButton;
    [SerializeField] CustomButton exitButton;

    public void InitializeView()
    {
        restartButton.onMouseEnter.AddListener(() => ScaleButtonUp(restartButton));
        restartButton.onMouseExit.AddListener(() => ScaleButtonDown(restartButton));

        exitButton.onMouseEnter.AddListener(() => ScaleButtonUp(exitButton));
        exitButton.onMouseExit.AddListener(() => ScaleButtonDown(exitButton));
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
