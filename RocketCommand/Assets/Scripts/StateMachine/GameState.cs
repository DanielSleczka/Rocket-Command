using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : BaseState
{
    private ShootingController shootingController;
    private BuildingController buildingController;
    private MeteorController meteorController;
    private EnemyController enemyController;
    private ScoreSystem scoreSystem;
    private SaveSystem saveSystem;
    private GameView gameView;
    private PauseView pauseView;


    public GameState(ShootingController shootingController, BuildingController buildingController, MeteorController meteorController, EnemyController enemyController, 
                     ScoreSystem scoreSystem, SaveSystem saveSystem, GameView gameView, PauseView pauseView)
    {
        this.shootingController = shootingController;
        this.buildingController = buildingController;
        this.meteorController = meteorController;
        this.enemyController = enemyController;
        this.scoreSystem = scoreSystem;
        this.saveSystem = saveSystem;
        this.gameView = gameView;
        this.pauseView = pauseView;
    }
    public override void InitializeState()
    {
        base.InitializeState();
        Debug.Log("Initialize GameState");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Debug.Log("Update GameState");
    }

    public override void DestroyState()
    {
        base.DestroyState();
    }
}
