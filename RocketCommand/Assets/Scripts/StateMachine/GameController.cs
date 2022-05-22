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
    [SerializeField] private MeteorController meteorController;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private BuildingController buildingController;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private SaveSystem saveSystem;
    [SerializeField] private LoadingSystem loadingSystem;

    #endregion

    #region VIEWS

    [SerializeField] private GameView gameView;
    [SerializeField] private LoseView loseView;
    [SerializeField] private LoadingView loadingView;

    #endregion

    protected override void InjectReferences()
    {
        gameState = new GameState(shootingController, meteorController, enemyController, buildingController, scoreSystem, saveSystem, gameView);
        loseState = new LoseState(scoreSystem, saveSystem, loadingSystem, loadingView, loseView);
    }

    protected override void Start()
    {
        base.Start();
        ChangeState(gameState);
        shootingController.GameOver_AddListener(() => ChangeState(loseState));
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}
