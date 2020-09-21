using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private Button _playButton;
    private Button _quitButton;


    private string _levelToLoad = "LevelSelect";

    private void Start()
    {
        _playButton = GameObject.Find("Play").GetComponent<Button>();
        _quitButton = GameObject.Find("Quit").GetComponent<Button>();

        _playButton.onClick.AddListener(Play);
        _quitButton.onClick.AddListener(Quit);
    }

    public void Play()
    {
        SceneManager.LoadScene(_levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
