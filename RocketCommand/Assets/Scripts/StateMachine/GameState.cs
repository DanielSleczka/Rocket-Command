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
    private GameView gameView;


    public GameState(ShootingController shootingController, MeteorController meteorController, EnemyController enemyController, BuildingController buildingController, 
                     ScoreSystem scoreSystem, SaveSystem saveSystem, GameView gameView)
    {
        this.shootingController = shootingController;
        this.meteorController = meteorController;
        this.enemyController = enemyController;
        this.buildingController = buildingController;
        this.scoreSystem = scoreSystem;
        this.saveSystem = saveSystem;
        this.gameView = gameView;
    }
    public override void InitializeState()
    {
        base.InitializeState();
        shootingController.InitializeController();
        meteorController.InitializeController();
        enemyController.InitializeController();
        buildingController.InitializeController();
        scoreSystem.InitializeSystem();
        gameView.ShowView();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        shootingController.UpdateController();
        meteorController.UpdateController();
        enemyController.UpdateController();
        buildingController.UpdateController();
    }

    public override void DestroyState()
    {
        base.DestroyState();
    }
}
