using UnityEngine;

public class MenuState : BaseState
{
    private MenuView menuView;
    private ExitPopup exitPopup;
    private LoadingView loadingView;
    private LoadingSystem loadingSystem;
    //private SaveSystem saveSystem;

    public MenuState(MenuView menuView, ExitPopup exitPopup, LoadingView loadingView, LoadingSystem loadingSystem)
    {
        this.menuView = menuView;
        this.exitPopup = exitPopup;
        this.loadingView = loadingView;
        this.loadingSystem = loadingSystem;
        //this.saveSystem = saveSystem;
    }

    public override void InitializeState()
    {
        base.InitializeState();
        menuView.InitializeView();
        menuView.ShowView();
        exitPopup.InitializePopup();

        menuView.OnStartGameButtonClicked_AddListener(loadingSystem.StartGame);
        menuView.OnExitButtonClicked_AddListener(exitPopup.ShowView);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void DestroyState()
    {
        base.DestroyState();
    }

    public void StartTheGame()
    {
        Debug.Log("DUPA");
    }
}
 