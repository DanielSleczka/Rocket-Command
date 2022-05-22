using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : BaseState
{
    private ScoreSystem scoreSystem;
    private SaveSystem saveSystem;
    private LoadingSystem loadingSystem;
    private LoadingView loadingView;
    private LoseView loseView;

    public LoseState(ScoreSystem scoreSystem, SaveSystem saveSystem, LoadingSystem loadingSystem, LoadingView loadingView, LoseView loseView)
    {
        this.scoreSystem = scoreSystem;
        this.saveSystem = saveSystem;
        this.loadingSystem = loadingSystem;
        this.loadingView = loadingView;
        this.loseView = loseView;
    }


    public override void InitializeState()
    {
        base.InitializeState();
        loseView.ShowView();
        loseView.OnRestartGameButtonClicked_AddListener(ResetLevel);
        loseView.OnExitButtonClicked_AddListener(ReturnToMainMenu);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void DestroyState()
    {
        base.DestroyState();
    }

    private void ResetLevel()
    {
        loadingView.ShowView();
        loadingSystem.StartLoadingScene(1);
    }
    private void ReturnToMainMenu()
    {
        loadingView.ShowView();
        loadingSystem.StartLoadingScene(0);
    }





}
