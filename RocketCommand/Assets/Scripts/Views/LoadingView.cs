using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingView : BaseView
{
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private Animator loadingAnimator;

        
    public override void ShowView()
    {
        base.ShowView();
        StartCoroutine(AnimText());
        loadingAnimator.SetTrigger("LoadingAnim");
    }
    public override void HideView()
    {
        base.HideView();
    }

    public IEnumerator AnimText()
    {
        while(true)
        {
            loadingText.text = "LOADING";
            yield return new WaitForSeconds(0.5f);            
            loadingText.text = "LOADING.";
            yield return new WaitForSeconds(0.5f);            
            loadingText.text = "LOADING..";
            yield return new WaitForSeconds(0.5f);            
            loadingText.text = "LOADING...";
            yield return new WaitForSeconds(0.5f);
        }

    }


}
