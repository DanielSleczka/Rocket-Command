using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseView : MonoBehaviour
{

    public void ShowView()
    {
        gameObject.SetActive(true);
    }

    public void HideView()
    {
        gameObject.SetActive(false);
    }

    public void ScaleButtonUp(CustomButton button)
    {
        button.transform.DOScale(1.2f, 0.2f);
    }

    public void ScaleButtonDown(CustomButton button)
    {
        button.transform.DOScale(1f, 0.2f);
    }
    public void ScaleButtonUpAndDown(Button button)
    {
        button.transform.DOScale(1.2f, 0.2f).OnComplete(() => button.transform.DOScale(1f, 0.2f));
    }
}
