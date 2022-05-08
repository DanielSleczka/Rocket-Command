using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
    private BaseState currentlyActiveState;

    protected abstract void InjectReferences();

    protected virtual void Start()
    {
        InjectReferences();
        currentlyActiveState?.InitializeState();
    }

    protected virtual void Update()
    {
        currentlyActiveState?.UpdateState();
    }

    protected virtual void OnDestroy()
    {
        currentlyActiveState?.DestroyState();
    }

    public void ChangeState(BaseState newState)
    {
        currentlyActiveState?.DestroyState();
        currentlyActiveState = newState;
        currentlyActiveState?.InitializeState();
    }
}
