using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverWinScript
{
    private Button _retryButton;
    private Button _menuButton;
    private Text _gameOverText;
    private GameObject _gameOverUiGameObject;
    public void Init()
    {
        _gameOverUiGameObject = GameObject.Find("UIGameOver");
        _retryButton = _gameOverUiGameObject.transform.Find("Retry").GetComponent<Button>();
        _menuButton = _gameOverUiGameObject.transform.Find("Menu").GetComponent<Button>();
        _gameOverText = _gameOverUiGameObject.transform.Find("GameOverText").GetComponent<Text>();
        _retryButton.onClick.AddListener(RetryGameOver);
        _menuButton.onClick.AddListener(MenuGameOver);
        _gameOverUiGameObject.SetActive(false);
    }

    public void EndGame(bool value)
    {
        _gameOverUiGameObject.SetActive(true);
        _gameOverText.text = value ? "GAME OVER" : "WIN GAME";
        PlayerStats.isGameOver = true;
    }

    public void RetryGameOver()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuGameOver()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
