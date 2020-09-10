using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;


    public string levelToLoad = "LevelSelect";

    private void Start()
    {
        playButton = GameObject.Find("Play").GetComponent<Button>();
        quitButton = GameObject.Find("Quit").GetComponent<Button>();

        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }

    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
