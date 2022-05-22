using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameView : BaseView
{
    [SerializeField] private TextMeshProUGUI pointsValue;

    public override void ShowView()
    {
        base.ShowView();
        pointsValue = transform.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdatePoints(float value)
    {
        pointsValue.text = $"{value}";
    }

    public void ChangeScale(Vector2 scale)
    {
        pointsValue.transform.DOScale(scale, .2f).OnComplete(() => pointsValue.transform.DOScale(Vector2.one, .2f));
    }

}
