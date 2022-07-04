using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private float timeProgress;
    private float startTime;
    private float duration;



    public void WaitATime()
    {
        startTime = Time.time;
        timeProgress = (Time.time - startTime) / duration;
       
        if (timeProgress >= 1f)
        {
            
        }
    }


}
