using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuView : BaseView
{
    [SerializeField] CustomButton startGameButton;
    [SerializeField] CustomButton instructionButton;
    [SerializeField] CustomButton exitGameButton;

    public void InitializeView()
    {
        base.ShowView();
        startGameButton.onMouseEnter.AddListener(() => startGameButton.ScaleButtonUp(startGameButton));
        startGameButton.onMouseExit.AddListener(() => startGameButton.ScaleButtonDown(startGameButton));

        instructionButton.onMouseEnter.AddListener(() => instructionButton.ScaleButtonUp(instructionButton));
        instructionButton.onMouseExit.AddListener(() => startGameButton.ScaleButtonDown(instructionButton));

        exitGameButton.onMouseEnter.AddListener(() => exitGameButton.ScaleButtonUp(exitGameButton));
        exitGameButton.onMouseExit.AddListener(() => exitGameButton.ScaleButtonDown(exitGameButton));
    }



}
