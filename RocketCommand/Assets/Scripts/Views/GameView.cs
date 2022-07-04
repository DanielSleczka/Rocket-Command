using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameView : BaseView
{
    [SerializeField] private TextMeshProUGUI pointsValue;

    public void UpdatePoints(float value)
    {
        pointsValue.text = $"{value}";
    }

    //public void ChangeScale(Vector2 scale)
    //{
    //    pointsValue.transform.DOScale(scale, .2f).OnComplete(() => pointsValue.transform.DOScale(Vector2.one, .2f));
    //}

}
