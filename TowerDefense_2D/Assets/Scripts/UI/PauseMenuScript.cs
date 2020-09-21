using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    private Button _refreshButton;
    private Button _menuButton;
    private Button _continueButton;

    private void Start()
    {

        _continueButton = GameObject.Find("ContinuePause").GetComponent<Button>();
        _refreshButton = GameObject.Find("RetryPause").GetComponent<Button>();
        _menuButton = GameObject.Find("MenuPause").GetComponent<Button>();

        _continueButton.onClick.AddListener(Toggle);
        _menuButton.onClick.AddListener(Menu);
        _refreshButton.onClick.AddListener(Retry);

    }

    public void Toggle()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
