using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Bonuses
{
    SpeedBonus,
    SlowMo,
    Shield,
    KillThemAll
}


public class Bonus : MonoBehaviour
{
    public Bonuses bonus;
    private Vector2 scale = Vector2.one * 8f;

    private void Start()
    {
        transform.DOScale(scale, 0.3f).OnComplete(() => transform.DOScale(Vector2.zero, 3f));
        Destroy(gameObject, 3f);
    }

}
