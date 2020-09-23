using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    MainMenu,
    LevelSelect,
    Game
}
public class Main : MonoBehaviour
{
    private GameState currentState;
    private MainMenuScript _mainMenuScript;
    private LevelSelectorScript _levelSelectorScript;
    public static Main instance;



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            Debug.Log("More one Main manager");
        }
        instance = this;
    }

    void Start()
    {
        _mainMenuScript = new MainMenuScript();
        _levelSelectorScript = new LevelSelectorScript();
        _mainMenuScript.Init();
        _levelSelectorScript.Init();
        ChangeState(GameState.MainMenu);
    }
    public void ChangeState(GameState newState)
    {
        switch (currentState)
        {
            case GameState.MainMenu:
                _mainMenuScript.Hide();
                break;
            case GameState.Game:
                break;
            case GameState.LevelSelect:
                _levelSelectorScript.Hide();

                break;
        }
        currentState = newState;

        switch (currentState)
        {
            case GameState.MainMenu:
                _mainMenuScript.Show();
                break;
            case GameState.Game:
                break;
            case GameState.LevelSelect:
                _levelSelectorScript.Show();
                break;
        }
    }
}
