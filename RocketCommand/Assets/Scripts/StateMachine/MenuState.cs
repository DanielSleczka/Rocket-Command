using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : BaseState
{
    private MenuView menuView;
    private ScoreSystem scoreSystem;
    private SaveSystem saveSystem;

    public MenuState(MenuView menuView, ScoreSystem scoreSystem, SaveSystem saveSystem)
    {
        this.menuView = menuView;
        this.scoreSystem = scoreSystem;
        this.saveSystem = saveSystem;
    }

    public override void InitializeState()
    {
        base.InitializeState();
        menuView.InitializeView();
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
