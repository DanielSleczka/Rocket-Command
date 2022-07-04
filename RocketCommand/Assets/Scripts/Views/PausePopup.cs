using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PausePopup : BaseView
{
    [SerializeField] private CustomButton resetButton;
    [SerializeField] private CustomButton exitButton;
    

    public void InitializePopup()
    {
        resetButton.onMouseEnter.AddListener(() => ScaleButtonUp(resetButton));
        resetButton.onMouseExit.AddListener(() => ScaleButtonDown(resetButton));

        exitButton.onMouseEnter.AddListener(() => ScaleButtonUp(exitButton));
        exitButton.onMouseExit.AddListener(() => ScaleButtonDown(exitButton));

        resetButton.onClick.AddListener(resetButton.RemoveAllListeners);
        exitButton.onClick.AddListener(Application.Quit);
    }

    public override void ShowView()
    {
        transform.localScale = new Vector3(0f, 0f, 1f);
        base.ShowView();
        transform.DOScale(1f, .2f).SetUpdate(true);
    }

    public override void HideView()
    {
        transform.DOScale(new Vector3(0f, 0f, 1f), .2f).OnComplete(base.HideView).SetUpdate(true);
        transform.localScale = new Vector3(1f, 1f, 1f);
        //Time.timeScale = 1;
    }

    public void OnResetButtonClicked_AddListener(UnityAction listener)
    {
        resetButton.onClick.AddListener(listener);
    }

    public void OnResetButtonClicked_RemoveListener(UnityAction listener)
    {
        resetButton.onClick.RemoveListener(listener);
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
