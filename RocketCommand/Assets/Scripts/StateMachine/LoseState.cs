using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : BaseState
{
    private LoseView loseView;
    private ScoreSystem scoreSystem;
    private SaveSystem saveSystem;

    public LoseState(LoseView loseView, ScoreSystem scoreSystem, SaveSystem saveSystem)
    {
        this.loseView = loseView;
        this.scoreSystem = scoreSystem;
        this.saveSystem = saveSystem;
    }


    public override void InitializeState()
    {
        base.InitializeState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void DestroyState()
    {
        base.DestroyState();
    }
}
