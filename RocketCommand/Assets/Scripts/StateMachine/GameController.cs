using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseController
{
    #region STATES
    private GameState gameState;
    private LoseState loseState;
    #endregion

    #region SYSTEMS

    [SerializeField] private ShootingController shootingController;
    [SerializeField] private BuildingController buildingController;
    [SerializeField] private MeteorController meteorController;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private SaveSystem saveSystem;

    #endregion

    #region VIEWS

    [SerializeField] private GameView gameView;
    [SerializeField] private PauseView pauseView;
    [SerializeField] private LoseView loseView;

    #endregion

    protected override void InjectReferences()
    {
        gameState = new GameState(shootingController, buildingController, meteorController, enemyController, scoreSystem, saveSystem, gameView, pauseView);
        loseState = new LoseState(loseView, scoreSystem, saveSystem);
    }

    protected override void Start()
    {
        base.Start();
        //ChangeState(gameState);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}
