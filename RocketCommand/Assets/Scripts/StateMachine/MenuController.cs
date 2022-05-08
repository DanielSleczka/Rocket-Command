using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : BaseController
{
    #region STATES
    private MenuState menuState;

    #endregion

    #region SYSTEMS

    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private SaveSystem saveSystem;

    #endregion

    #region VIEWS

    [SerializeField] private MenuView menuView;

    #endregion

    protected override void InjectReferences()
    {
        menuState = new MenuState(menuView, scoreSystem, saveSystem);
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
