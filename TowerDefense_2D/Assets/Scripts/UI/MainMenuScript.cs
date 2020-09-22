using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript
{
    private Button _playButton;
    private Button _quitButton;
    private string _levelToLoad = "LevelSelect";
    public GameObject mainMenuGamObj;
    private Main _main;

    public void Init()
    {
        _playButton = GameObject.Find("Play").GetComponent<Button>();
        _quitButton = GameObject.Find("Quit").GetComponent<Button>();
        _main = GameObject.Find("UI").GetComponent<Main>();
        mainMenuGamObj = GameObject.Find("MainMenu");

        _playButton.onClick.AddListener(Play);
        _quitButton.onClick.AddListener(Quit);
        Hide();
    }

    public void Show()
    {
        mainMenuGamObj.SetActive(true);
    }

    public void Hide()
    {
        mainMenuGamObj.SetActive(false);
    }
    public void Play()
    {
        _main.ChangeState(GameState.LevelSelect);
    }

    public void Quit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
