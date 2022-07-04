using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState
{
    private ShootingController shootingController;
    private MeteorController meteorController;
    private EnemyController enemyController;
    private BuildingController buildingController;

    private ScoreSystem scoreSystem;
    private SaveSystem saveSystem;
    private LoadingSystem loadingSystem;

    private LoadingView loadingView;
    private GameView gameView;
    private PausePopup pausePopup;


    private bool isActive;


    public GameState(ShootingController shootingController, MeteorController meteorController, EnemyController enemyController, BuildingController buildingController,
                     ScoreSystem scoreSystem, SaveSystem saveSystem, LoadingSystem loadingSystem, LoadingView loadingView, GameView gameView, PausePopup pausePopup)
    {
        this.shootingController = shootingController;
        this.meteorController = meteorController;
        this.enemyController = enemyController;
        this.buildingController = buildingController;
        this.scoreSystem = scoreSystem;
        this.saveSystem = saveSystem;
        this.loadingSystem = loadingSystem;
        this.loadingView = loadingView;
        this.gameView = gameView;
        this.pausePopup = pausePopup;
    }
    public override void InitializeState()
    {
        base.InitializeState();
        shootingController.InitializeController();
        meteorController.InitializeController();
        enemyController.InitializeController();
        buildingController.InitializeController();
        scoreSystem.InitializeSystem();
        pausePopup.InitializePopup();

        pausePopup.OnResetButtonClicked_AddListener(ResetLevel);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        shootingController.UpdateController();
        meteorController.UpdateController();
        enemyController.UpdateController();
        buildingController.UpdateController();
        UpdateInput();
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

    public void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isActive)
            {
                Time.timeScale = 0;
                pausePopup.ShowView();
                isActive = true;
            }
            else if (isActive)
            {
                Time.timeScale = 1;
                pausePopup.HideView();
                isActive = false;
            }
        }
    }
}
