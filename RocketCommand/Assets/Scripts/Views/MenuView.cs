using UnityEngine;
using UnityEngine.Events;

public class MenuView : BaseView
{
    [SerializeField] CustomButton startGameButton;
    [SerializeField] CustomButton instructionButton;
    [SerializeField] CustomButton exitButton;

    public void InitializeView()
    {
        startGameButton.onMouseEnter.AddListener(() => ScaleButtonUp(startGameButton));
        startGameButton.onMouseExit.AddListener(() => ScaleButtonDown(startGameButton));

        instructionButton.onMouseEnter.AddListener(() => ScaleButtonUp(instructionButton));
        instructionButton.onMouseExit.AddListener(() => ScaleButtonDown(instructionButton));

        exitButton.onMouseEnter.AddListener(() => ScaleButtonUp(exitButton));
        exitButton.onMouseExit.AddListener(() => ScaleButtonDown(exitButton));

        startGameButton.onClick.AddListener(startGameButton.RemoveAllListeners);
    }

    public void OnStartGameButtonClicked_AddListener(UnityAction listener)
    {
        startGameButton.onClick.AddListener(listener);
    }

    public void OnStartGameButtonClicked_RemoveListener(UnityAction listener)
    {
        startGameButton.onClick.RemoveListener(listener);
    }

    public void OnExitButtonClicked_AddListener(UnityAction listener)
    {
        exitButton.onClick.AddListener(listener);
    }    
    
    public void OnExitButtonClicked_RemoveListener(UnityAction listener)
    {
        exitButton.onClick.RemoveListener(listener);
    }



}
