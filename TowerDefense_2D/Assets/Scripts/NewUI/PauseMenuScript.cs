using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public Button refreshButton;
    public Button menuButton;
    public Button continueButton;

    private void Start()
    {

        continueButton = GameObject.Find("ContinuePause").GetComponent<Button>();
        refreshButton = GameObject.Find("RetryPause").GetComponent<Button>();
        menuButton = GameObject.Find("MenuPause").GetComponent<Button>();

        continueButton.onClick.AddListener(Toggle);
        menuButton.onClick.AddListener(Menu);
        refreshButton.onClick.AddListener(Retry);

    }

    public void Toggle()
    {
        if (!gameObject.activeSelf)
        {
            Debug.Log("Active");
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Debug.Log("Disactive");
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
