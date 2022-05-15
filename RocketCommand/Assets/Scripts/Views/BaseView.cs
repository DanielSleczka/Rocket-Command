using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseView : MonoBehaviour
{

    public virtual void ShowView()
    {
        gameObject.SetActive(true);
    }

    public virtual void HideView()
    {
        gameObject?.SetActive(false);
    }

    public void ScaleButtonUp(CustomButton button)
    {
        button.transform.DOScale(1.2f, 0.2f);
    }

    public void ScaleButtonDown(CustomButton button)
    {
        button.transform.DOScale(1f, 0.2f);
    }
}
