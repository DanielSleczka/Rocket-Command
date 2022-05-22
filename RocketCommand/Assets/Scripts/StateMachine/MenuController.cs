using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : BaseController
{
    #region STATES
    private MenuState menuState;

    #endregion

    #region SYSTEMS

    [SerializeField] private LoadingSystem loadingSystem;
    //[SerializeField] private SaveSystem saveSystem;

    #endregion

    #region VIEWS

    [SerializeField] private MenuView menuView;
    [SerializeField] private ExitPopup exitPopup;
    [SerializeField] private LoadingView loadingView;

    #endregion

    protected override void InjectReferences()
    {
        menuState = new MenuState(menuView, exitPopup, loadingView, loadingSystem);
    }

    protected override void Start()
    {
        base.Start();
        ChangeState(menuState);
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

    }



}
