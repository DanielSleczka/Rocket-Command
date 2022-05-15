using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPopup : BaseView
{
    [SerializeField] private CustomButton yesButton;
    [SerializeField] private CustomButton noButton;

    public void InitializePopup()
    {
        yesButton.onMouseEnter.AddListener(() => ScaleButtonUp(yesButton));
        yesButton.onMouseExit.AddListener(() => ScaleButtonDown(yesButton));

        noButton.onMouseEnter.AddListener(() => ScaleButtonUp(noButton));
        noButton.onMouseExit.AddListener(() => ScaleButtonDown(noButton));

        yesButton.onClick.AddListener(Application.Quit);
        noButton.onClick.AddListener(HideView);
    }

    public override void ShowView()
    {
        transform.localScale = new Vector3(0f, 0f, 1f);
        base.ShowView();
        transform.DOScale(1f, .2f);
    }

    public override void HideView()
    {
        transform.DOScale(new Vector3(0f, 0f, 1f), .2f).OnComplete(base.HideView);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
