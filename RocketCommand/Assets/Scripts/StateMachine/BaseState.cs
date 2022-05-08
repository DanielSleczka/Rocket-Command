using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    public virtual void InitializeState()
    {
        
    }    
    
    public virtual void UpdateState()
    {

    }    
    
    public virtual void DestroyState()
    {

    }

}
